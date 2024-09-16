<script lang="ts" setup>
const model = defineModel<string>();
const modelDate = ref<Date>(model.value ? new Date(model.value) : new Date());

watch(modelDate, (value) => {
	model.value = value.toISOString();
});

const visible = defineModel<boolean>("visible");

const emit = defineEmits(["close"]);

function closeModalScheduled() {
	emit("close");
}
</script>

<template>
  <Dialog v-model:visible="visible" modal header="Agendar post" :style="{ width: '25rem' }">
    <div class="mb-3">
      <label for="username" class="font-semibold w-24">Data e hora da postagem</label>
      <DatePicker v-model="modelDate" show-time />
    </div>
    <div class="flex justify-content-end gap-2">
      <Button type="button" label="Cancel" severity="secondary" @click="closeModalScheduled" />
      <Button type="button" label="Save" @click="closeModalScheduled" />
    </div>
  </Dialog>
</template>
