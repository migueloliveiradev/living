<script lang="ts" setup>
import type { FileUploadSelectEvent } from "primevue/fileupload";
import Image from "primevue/image";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const props = defineProps<{
	multiple: boolean;
	accept: string;
	label: string;
}>();

const model = defineModel<File[]>();

function onFileSelect(event: FileUploadSelectEvent) {
	model.value = event.files;
}
</script>

<template>
  <div>
    <label class="block mb-1">{{ label }}</label>
    <FileUpload
      :multiple="multiple"
      :accept="accept"
      :max-file-size="1000000"
      :show-upload-button="false"
      :show-cancel-button="false"
      @select="onFileSelect"
    >
      <template #content>
        <div v-for="(file, index) in model" :key="index">
          <Image :src="file.objectURL" alt="Image" width="250" preview />
        </div>
      </template>
    </FileUpload>
  </div>
</template>
