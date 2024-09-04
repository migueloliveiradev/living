import type { components } from "~/api/schema";

export type FilterMethods<T> = {
	[K in keyof Omit<T, "parameters"> as T[K] extends never | undefined
		? never
		: K]: T[K];
};

export type ExtractRequest<T> = Required<T> extends {
	requestBody: { content: { "application/json": infer R } };
}
	? R
	: never;

export type ExtractResponse<T> = T extends {
	responses: { 200: { content: { "application/json": infer R } } };
}
	? R
	: never;

export type ExtractData<T> = Required<T> extends { data: infer R } ? R : never;

export type ExtractBaseResponse<T> = Required<T> extends {
	data: infer R;
	notifications: infer N;
	hasNotifications: infer H;
	httpStatusCode: infer S;
} ? {
			data: R;
			notifications: N;
			hasNotifications: H;
			httpStatusCode: S;
		} : never;

export type ExtractNotification<T> = Required<T> extends {
	notifications: infer R;
}
	? R
	: never;

export type Notification =
  components["schemas"]["BaseResponse"]["notifications"];
