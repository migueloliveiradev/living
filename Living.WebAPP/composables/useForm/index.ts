import type { paths } from "~/api/schema";
import type {
	ExtractBaseResponse,
	ExtractData,
	ExtractRequest,
	ExtractResponse,
	FilterMethods,
	Notification,
} from "~/composables/useApi/types";

export function useForm<
	ReqT extends keyof paths,
	Methods extends FilterMethods<paths[ReqT]>,
	Method extends keyof Methods,
	TRequest = ExtractRequest<Methods[Method]>,
	TResponse = ExtractResponse<Methods[Method]>,
>(
	path: ReqT,
	method: Method,
	defaultForm?: Partial<TRequest>,
	onSuccess?: (response: ExtractData<TResponse>) => void,
) {
	const form = ref<Partial<TRequest>>(defaultForm || {});
	const response = ref<ExtractData<TResponse>>();
	const errors = ref<Notification>({});

	async function submit() {
		const { data } = await useApi(path, {
			method: method as unknown as keyof FilterMethods<paths[ReqT]>,
			body: form.value as TRequest,
		});

		if (!data.value) return;

		const result = data.value as ExtractBaseResponse<TResponse>;

		response.value = result.data as ExtractData<TResponse>;
		errors.value = result.notifications as Notification;

		if (!result.hasNotifications && onSuccess) {
			onSuccess(response.value);
		}
	}

	return {
		form,
		errors,
		submit,
		response,
	};
}
