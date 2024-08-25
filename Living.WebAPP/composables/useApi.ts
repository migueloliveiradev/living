export type HTTPMethod = "GET" | "PATCH" | "POST" | "PUT" | "DELETE";

export interface BaseResponse<T = unknown> {
  hasNotifications: boolean;
  notifications: Notification;
  data: T;
}

export interface Notification {
  [key: string]: string[];
}

export default async function useApi<TResponse = unknown>(
  method: HTTPMethod,
  path: string,
  body?: object | string | FormData | null
) {
  const { data } = await useFetch<BaseResponse<TResponse>>(path, {
    method: method,
    body: body,
    baseURL: "https://localhost:7129",
    ignoreResponseError: true,
    credentials: "include",
  });

  console.log(data);

  const errors = computed(() => data.value?.notifications || {});
  return {
    errors,

    data: ref(data.value),
  };
}
