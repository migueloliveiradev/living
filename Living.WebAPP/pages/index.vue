<script setup>
import { ref } from "vue";

const items = ref([
    {
        label: 'Home'
    },
    {
        label: 'Contribuidores'
    },
    {
        label: 'Status'
    },
    {
        label: 'Sobre'
    },
    {
        label: 'Feed',
        route: '/feed'
    }
]);
</script>

<template>
    <div class="card">
        <Menubar :model="items">
            <template #item="{ item, props, hasSubmenu }">
                <NuxtLink v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
                    <a v-ripple :href="href" v-bind="props.action" @click="navigate">
                        <span :class="item.icon" />
                        <span class="ml-2">{{ item.label }}</span>
                    </a>
                </NuxtLink>
                <a v-else v-ripple :href="item.url" :target="item.target" v-bind="props.action">
                    <span :class="item.icon" />
                    <span class="ml-2">{{ item.label }}</span>
                    <span v-if="hasSubmenu" class="pi pi-fw pi-angle-down ml-2" />
                </a>
            </template>
            <template #end>
                <div class="flex align-items-center gap-2 justify-center">
                    <label class="mt-4">Olá, <strong>Miguel Oliveira</strong></label>
                    <UAvatar size="xl" src="https://avatars.githubusercontent.com/u/87040481" alt="Avatar" />
                </div>
            </template>
        </Menubar>
    </div>
</template>