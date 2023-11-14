export default defineNuxtConfig({
  devtools: { enabled: true },
  modules: ["nuxt-auth-utils", "@nuxt/ui"],
  css: [
    "~/node_modules/bootstrap/dist/css/bootstrap.min.css",
    "~/assets/css/main.scss",
  ],
});
