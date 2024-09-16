<script lang="ts" setup>
const { content } = defineProps<{
	content: string;

}>();
</script>

<template>
  <div class="card">
    <Fieldset>
      <template #legend>
        <div class="flex items-center pl-2">
          <Avatar image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png" shape="circle" />
          <span class="font-bold p-2">Amy Elsner</span>
        </div>
      </template>
      <p class="m-0" v-html="content" />
    </Fieldset>
  </div>
</template>
