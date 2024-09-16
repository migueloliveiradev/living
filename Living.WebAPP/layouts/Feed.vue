<script lang="ts" setup>
import Card from "primevue/card";
import type { MenuItem } from "primevue/menuitem";
import { ref } from "vue";

const items = ref<MenuItem[]>([
	{
		label: "Feed",
		icon: "pi pi-file",
		url: "/feed",

	},
	{
		label: "Criar",
		icon: "pi pi-pencil",
		url: "/posts/create",
	},
	{
		label: "Explorar",
		icon: "pi pi-objects-column",
	},
	{
		label: "Notificações",
		icon: "pi pi-bell",
	},
	{
		label: "Mensagens",
		icon: "pi pi-inbox",

	},

	{
		label: "Settings",
		icon: "pi pi-cog",
	},
	{
		label: "Logout",
		icon: "pi pi-sign-out",
	},

]);
</script>

<template>
  <div class="card flex justify-center">
    <div class="sidebar">
      <PanelMenu
        :model="items"
        class="w-full md:w-80 max-w-19rem mt-8	"
      >
        <template #item="{ item }">
          <NuxtLink
            v-ripple
            class="flex items-center px-4 py-2 cursor-pointer group"
            :to="item.url"
          >
            <span :class="[item.icon, 'text-primary group-hover:text-inherit']" />
            <span :class="['ml-2', { 'font-semibold': item.items }]">{{ item.label }}</span>
            <Badge
              v-if="item.badge"
              class="ml-auto"
              :value="item.badge"
            />
          </NuxtLink>
        </template>
      </PanelMenu>
      <div class="profile-card">
        <Card>
          <template #title>
            Perfil
          </template>
          <template #content>
            <div class="flex">
              <Avatar image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png" shape="circle" class="mt-2" />
              <p class="ml-2">
                Miguel Oliveira
              </p>
            </div>
          </template>
        </Card>
      </div>
    </div>
    <div class="m-5 w-full">
      <slot />
    </div>
  </div>
</template>

<style lang="css" scoped>
.sidebar {
  border-right: 0.3px solid #e0e0e0;
  padding-right: 5px;
  height: 100vh;
  overflow-y: auto;
  width: 19rem;
  z-index: 100;
  position: relative;
}

.profile-card {
  position: absolute;
  bottom: 0;
  width: 100%;
  padding: 1rem;
  box-sizing: border-box;
  border-top: 0.3px solid #e0e0e0;
}
</style>
