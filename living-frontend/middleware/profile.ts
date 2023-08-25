export default defineNuxtRouteMiddleware((to, from) => {
    if (!userExist()) {
        return abortNavigation({ message: "Usuario não existe", statusCode: 404 })
    }
})

function userExist(): boolean {
    return true
}