export default defineNuxtRouteMiddleware((to, from) => {
    if (!isAuthenticated()) {
        return navigateTo('/')
    }
})

function isAuthenticated(): boolean {
    return true
}