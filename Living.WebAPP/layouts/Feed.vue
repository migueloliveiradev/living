<script lang="ts" setup>

import type { MenuItem } from "primevue/menuitem";
import { ref } from "vue";

const items = ref<MenuItem[]>([
  {
    label: 'Feed',
    icon: 'pi pi-file',
    url: "/feed"

  },
  {
    label: 'Explorar',
    icon: 'pi pi-objects-column',
  },
  {
    label: 'Notificações',
    icon: 'pi pi-bell',
  },
  {
    label: 'Mensagens',
    icon: 'pi pi-inbox',

  },
  {
    label: 'Profile',
    icon: 'pi pi-user',
    url: "/me"
  },
  {
    label: 'Mais',
    icon: 'pi pi-ellipsis-h',
    items: [
      {
        label: 'Settings',
        icon: 'pi pi-cog',
      },
      {
        label: 'Logout',
        icon: 'pi pi-sign-out',
      }
    ]
  }
]);

</script>

<template>

  <div class="card flex justify-center">
    <PanelMenu :model="items" class="w-full md:w-80 max-w-19rem mt-8	">
      <template #item="{ item }">
        <NuxtLink v-ripple class="flex items-center px-4 py-2 cursor-pointer group" :to="item.url">
          <span :class="[item.icon, 'text-primary group-hover:text-inherit']" />
          <span :class="['ml-2', { 'font-semibold': item.items }]">{{ item.label }}</span>
          <Badge v-if="item.badge" class="ml-auto" :value="item.badge" />
        </NuxtLink>
      </template>
    </PanelMenu>
    <div class="ml-5 w-full">

      <slot />
    </div>
  </div>

</template>