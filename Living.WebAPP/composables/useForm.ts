import type {
  HTTPMethod,
  BaseResponse,
  Notification,
} from "~/composables/useApi";
import useApi from "~/composables/useApi";

export default function useForm<TInput, TResponse = unknown>(
  defaultForm: Partial<TInput>,
  method: HTTPMethod,
  path: string
) {
  const form = ref<TInput>(defaultForm as TInput);
  const data = ref<BaseResponse<TResponse> | null>(null);
  const errors = ref<Notification>({});

  async function submit() {
    const { data: responseData, errors: responseErros } =
      await useApi<TResponse>(path, method, form.value as object);

    errors.value = responseErros.value;
    data.value = responseData.value;
  }

  return {
    form,
    errors,
    submit,
    data,
  };
}
