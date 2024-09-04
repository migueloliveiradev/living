export async function useAuth() {
	const { data, refresh } = await useApi("/api/auth/me", {
		method: "get",
		body: undefined,
	});

	const isAuthenticated = computed(() => {
		return !!data.value;
	});

	return {
		user: data.value?.data,
		isAuthenticated,
		refresh,
	};
}
