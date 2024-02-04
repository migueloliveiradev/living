// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: false },
  modules: ["nuxt-primevue", "@nuxtjs/i18n"],
  components: [
    {
      path: "~/components",
      pathPrefix: false,
    },
  ],
  i18n: {
    detectBrowserLanguage: {
      useCookie: true,
      cookieKey: "i18n_redirected",
      redirectOn: "root",
    },
    locales: [
      {
        code: "en",
        name: "English",
      },
      {
        code: "pt-br",
        name: "Português",
      },
    ],
  },
  primevue: {},
  css: [
    "primevue/resources/themes/aura-dark-green/theme.css",
    "primeicons/primeicons.css",
    "/node_modules/primeflex/primeflex.css",
  ],
});
