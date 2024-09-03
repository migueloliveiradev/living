<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const { user } = await useAuth();
</script>
<template>
  <NuxtLayout>
    <p>Ola {{ user?.name }}</p>
  </NuxtLayout>
</template>