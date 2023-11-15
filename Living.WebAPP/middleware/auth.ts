export default defineNuxtRouteMiddleware((to, from) => {
    if (!autorize()) {
        return navigateTo("/login");
    }
})

function autorize(): boolean {
    return true
}