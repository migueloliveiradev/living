<script lang="ts" setup>
import Select from "primevue/select";

interface SelectOptionsComponent {
	id?: string;
	options: Record<string, string>;
	label: string;
	placeholder?: string;
}

const { id, options, label, placeholder } = defineProps<SelectOptionsComponent>();

const model = defineModel<string>();

const computedOptions = computed(() => {
	return Object.entries(options).map(([key, value]) => ({
		label: key, // apply i18n
		code: value,
	}));
});
</script>

<template>
  <div>
    <label :for="id" class="mb-3">{{ label }}</label>
    <Select
      :id="id"
      v-model="model"
      option-value="code"
      :options="computedOptions"
      option-label="label"
      :placeholder="placeholder"
      class="w-full md:w-56 mt-1"
    />
  </div>
</template>
