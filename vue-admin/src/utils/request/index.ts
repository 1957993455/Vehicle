import { HttpRequest } from './HttpRequest'
import type { RequestConfig } from './types'

// 创建请求实例
const http = new HttpRequest({
  baseURL: import.meta.env.VITE_API_BASE_URL || '/api',
  timeout: 10000,
  retry: 3,
  retryDelay: 1000,
})

// 导出请求方法
export const get = <T = unknown>(
  url: string,
  params?: Record<string, unknown>,
  config?: RequestConfig,
): Promise<T> => {
  return http.get(url, params, config)
}

export const post = <T = unknown>(
  url: string,
  data?: Record<string, unknown>,
  config?: RequestConfig,
): Promise<T> => {
  return http.post(url, data, config)
}

export const put = <T = unknown>(
  url: string,
  data?: Record<string, unknown>,
  config?: RequestConfig,
): Promise<T> => {
  return http.put(url, data, config)
}

export const del = <T = unknown>(url: string, config?: RequestConfig): Promise<T> => {
  return http.delete(url, config)
}

export const patch = <T = unknown>(
  url: string,
  data?: Record<string, unknown>,
  config?: RequestConfig,
): Promise<T> => {
  return http.patch(url, data, config)
}
// 导出请求实例
export default http
