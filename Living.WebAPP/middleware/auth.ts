export default defineNuxtRouteMiddleware(async () => {
	const { user } = await useAuth();

	if (!user) {
		return navigateTo("/login");
	}
});
