<script lang="ts" setup>


const { user } = await useAuth();
</script>
<template>
  <NuxtLayout name="feed">
    <Post v-for="number in Array(5)" class="mt-2"/>
  </NuxtLayout>
</template>