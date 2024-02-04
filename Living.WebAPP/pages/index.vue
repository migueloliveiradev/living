<script setup lang="ts">

import type { MenuItem } from "primevue/menuitem";
import { ref } from "vue";

const { t, locale, messages } = useI18n({
    useScope: 'local'
})

const items = computed<MenuItem[]>(() => [
    {
        label: 'Living',
        icon: 'pi pi-home'
    },
    {
        label: t('menu_bar.signup'),
        icon: 'pi pi-star',
        url: '/signup'
    },
    {
        label: t('menu_bar.login'),
        icon: 'pi pi-search',
        url: '/login'
    },
]);

console.log('messages', messages.value);

console.log("lang", locale.value);

const languages = ref([
    { option: 'Portugues', code: 'pt-br' },
    { option: 'Inglês', code: 'en' },
]);

</script>
<template>
    <Menubar :model="items">
        <template #end>
            <Dropdown modelValue="locale" @change="(e) => locale = e.value.code" :options="languages" optionLabel="option"
                placeholder="Selecione um idioma" class="w-full md:w-14rem" />
            <p>{{ locale }}</p>
        </template>
    </Menubar>
</template>
<i18n lang="json">
{
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
}
</i18n>