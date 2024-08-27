import type { paths } from "~/api/schema";
import type {
  ExtractRequest,
  ExtractResponse,
  FilterMethods,
} from "~/composables/useApi/types";

export async function useApi<
  ReqT extends keyof paths,
  Methods extends FilterMethods<paths[ReqT]>,
  Method extends keyof Methods,
  TRequest = ExtractRequest<Methods[Method]>,
  TResponse = ExtractResponse<Methods[Method]>
>(
  path: ReqT,
  options: {
    method: Method;
    body: TRequest;
  }
) {
  const {
    public: { API_URL },
  } = useRuntimeConfig();
  return await useFetch<TResponse>(path, {
    method: options.method as unknown as undefined,
    baseURL: API_URL,
    body: JSON.stringify(options.body),
    ignoreResponseError: true,
    credentials: "include",
  });
}
