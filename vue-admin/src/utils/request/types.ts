import type { AxiosRequestConfig } from 'axios'

// 请求配置接口
export interface RequestConfig extends AxiosRequestConfig {
  retry?: number
  retryDelay?: number
  retryCount?: number
  skipRefreshToken?: boolean // 是否跳过刷新token
}

// 响应数据接口
export interface HttpResponse<T = unknown> {
  code: number
  data: T
  message: string
}

// 后端错误响应接口
export interface BackendError {
  code: string | null
  message: string
  details: string | null
  data: Record<string, unknown> | null
  validationErrors: Record<string, string[]> | null
}

// 错误处理接口
export interface ErrorResponse {
  code: number
  message: string
  error?: BackendError
}

// 请求实例配置接口
export interface RequestInstanceConfig {
  baseURL: string
  timeout: number
  retry: number
  retryDelay: number
}

// 刷新token响应接口
export interface RefreshTokenResponse {
  accessToken: string
  refreshToken: string
}

// 请求队列项接口
export interface RequestQueueItem {
  resolve: (value: unknown) => void
  reject: (reason?: unknown) => void
  config: RequestConfig
}
