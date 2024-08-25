<script setup lang="ts">
import type { MenuItem } from "primevue/menuitem";
import { ref } from "vue";

const { t, locale } = useI18n({
  useScope: "local",
});

const items = computed<MenuItem[]>(() => [
  {
    label: "Living",
    icon: "pi pi-home",
  },
  {
    label: t("menu_bar.signup"),
    icon: "pi pi-star",
    url: "/signup",
  },
  {
    label: t("menu_bar.login"),
    icon: "pi pi-search",
    url: "/login",
  },
]);

const languages = ref([
  { option: "Portugues", code: "pt-br" },
  { option: "Ingl�s", code: "en" },
]);
</script>
<template>
  <Menubar :model="items">
    <template #end>
      <Dropdown model-value="locale" :options="languages" option-label="option" placeholder="Selecione um idioma"
        class="w-full md:w-14rem" @change="(e) => (locale = e.value.code)" />
      <p>{{ locale }}</p>
    </template>
  </Menubar>
</template>
<i18n lang="json">{
  "en": {
    "menu_bar": {
      "signup": "Signup",
      "login": "Login"
    }
  },
  "pt-br": {
    "menu_bar": {
      "signup": "Cadastro",
      "login": "Login"
    }
  }
}</i18n>
