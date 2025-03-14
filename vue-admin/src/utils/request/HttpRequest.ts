import axios, { AxiosError, type InternalAxiosRequestConfig } from 'axios'
import type {
  RequestConfig,
  ErrorResponse,
  RequestInstanceConfig,
  RefreshTokenResponse,
  RequestQueueItem,
  BackendError,
  HttpResponse,
} from './types'

export class HttpRequest {
  private instance = axios.create()
  private pendingRequests = new Map<string, AbortController>()
  private isRefreshing = false
  private requestQueue: RequestQueueItem[] = []

  constructor(config: RequestInstanceConfig) {
    this.instance.defaults.baseURL = config.baseURL
    this.instance.defaults.timeout = config.timeout
    this.setupInterceptors()
  }

  // 生成请求标识
  private generateRequestKey(config: RequestConfig): string {
    const { url, method, params, data } = config
    return [url, method, JSON.stringify(params), JSON.stringify(data)].join('&')
  }

  // 刷新token
  private async refreshToken(): Promise<RefreshTokenResponse> {
    const storedRefreshToken = localStorage.getItem('refreshToken')
    if (!storedRefreshToken) {
      throw new Error('刷新token不存在')
    }

    try {
      const response = await this.instance.post<RefreshTokenResponse>('/auth/refresh-token', {
        refreshToken: storedRefreshToken,
      })
      return response.data
    } catch {
      throw new Error('刷新token失败')
    }
  }

  // 处理请求队列
  private processQueue(error: ErrorResponse | null = null): void {
    this.requestQueue.forEach(({ resolve, reject, config }) => {
      if (error) {
        reject(error)
      } else {
        resolve(this.instance(config))
      }
    })
    this.requestQueue.length = 0
  }

  // 处理后端错误
  private handleBackendError(error: AxiosError): ErrorResponse {
    const backendError = error.response?.data as BackendError
    return {
      code: error.response?.status || 500,
      message: backendError?.message || error.message || '请求失败',
      error: backendError,
    }
  }

  // 设置拦截器
  private setupInterceptors(): void {
    // 请求拦截器
    this.instance.interceptors.request.use(
      (config: InternalAxiosRequestConfig) => {
        // 添加取消请求功能
        const requestKey = this.generateRequestKey(config)
        if (this.pendingRequests.has(requestKey)) {
          this.pendingRequests.get(requestKey)?.abort()
        }
        const controller = new AbortController()
        config.signal = controller.signal
        this.pendingRequests.set(requestKey, controller)

        // 添加token
        const token = localStorage.getItem('token')
        if (token && config.headers) {
          config.headers.Authorization = `Bearer ${token}`
        }

        return config
      },
      (error: AxiosError) => {
        return Promise.reject(error)
      },
    )

    // 响应拦截器
    this.instance.interceptors.response.use<HttpResponse<any>>(
      (response) => {
        // 请求完成后，删除请求标识
        const requestKey = this.generateRequestKey(response.config)
        this.pendingRequests.delete(requestKey)

        // 将返回响应数据, 并进行类型转换
        const data = response.data as HttpResponse<any>
        return data
      },
      async (error: AxiosError) => {
        const config = error.config as RequestConfig

        // 请求被取消
        if (error.name === 'CanceledError') {
          return Promise.reject(new Error('请求已取消'))
        }

        // 请求重试
        if (config && config.retry) {
          config.retryCount = config.retryCount || 0
          if (config.retryCount < config.retry) {
            config.retryCount++
            return new Promise((resolve) => {
              setTimeout(() => {
                resolve(this.instance(config))
              }, config.retryDelay || 1000)
            })
          }
        }

        // 处理错误响应
        const errorResponse = this.handleBackendError(error)

        // 处理token过期
        if (error.response?.status === 401 && !config?.skipRefreshToken) {
          if (!this.isRefreshing) {
            this.isRefreshing = true
            try {
              const { accessToken, refreshToken } = await this.refreshToken()
              localStorage.setItem('token', accessToken)
              localStorage.setItem('refreshToken', refreshToken)
              this.processQueue()
              return this.instance(config)
            } catch (refreshError) {
              this.processQueue(refreshError as ErrorResponse)
              // 清除token并跳转到登录页
              localStorage.removeItem('token')
              localStorage.removeItem('refreshToken')
              window.location.href = '/login'
              return Promise.reject(refreshError)
            } finally {
              this.isRefreshing = false
            }
          } else {
            // 将请求添加到队列
            return new Promise((resolve, reject) => {
              this.requestQueue.push({ resolve, reject, config })
            })
          }
        }

        return Promise.reject(errorResponse)
      },
    )
  }

  // 请求方法
  public get<T = unknown>(
    url: string,
    params?: Record<string, unknown>,
    config?: RequestConfig,
  ): Promise<T> {
    return this.instance.get(url, { params, ...config })
  }

  public post<T = unknown>(
    url: string,
    data?: Record<string, unknown>,
    config?: RequestConfig,
  ): Promise<T> {
    return this.instance.post(url, data, config)
  }

  public put<T = unknown>(
    url: string,
    data?: Record<string, unknown>,
    config?: RequestConfig,
  ): Promise<T> {
    return this.instance.put(url, data, config)
  }

  public delete<T = unknown>(url: string, config?: RequestConfig): Promise<T> {
    return this.instance.delete(url, config)
  }

  public patch<T = unknown>(
    url: string,
    data?: Record<string, unknown>,
    config?: RequestConfig,
  ): Promise<T> {
    return this.instance.patch(url, data, config)
  }
}
