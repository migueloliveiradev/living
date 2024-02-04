export default function useForm<TInput, TResponse = unknown>(
  defaultForm: TInput,
  method: HTTPMethod,
  path: string
) {
  const form = ref<TInput>(defaultForm);
  const errors = ref<Notification>({});
  const data = ref<TResponse | null | undefined>(null);

  async function submit() {
    const {
      data: dataRespose,
      pending,
      error,
      status,
    } = await useFetch<BaseResponse<TResponse>>(path, {
      method: "POST",
      body: JSON.stringify(form.value),
      baseURL: "https://localhost:7129",
      ignoreResponseError: true,
    });

    errors.value = dataRespose.value?.notifications || {};
  }

  return {
    form,
    errors,
    submit,
    data,
  };
}
export interface BaseResponse<T extends unknown> {
  hasNotifications: boolean;
  notifications: Notification;
  data: T;
}

export interface Notification {
  [key: string]: string[];
}

type HTTPMethod =
  | "GET"
  | "HEAD"
  | "PATCH"
  | "POST"
  | "PUT"
  | "DELETE"
  | "CONNECT"
  | "OPTIONS"
  | "TRACE"
  | "get"
  | "head"
  | "patch"
  | "post"
  | "put"
  | "delete"
  | "connect"
  | "options"
  | "trace"
  | undefined;
