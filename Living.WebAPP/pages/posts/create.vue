<script lang="ts" setup>
import { PostAccess } from "~/api/schema";
import type { Post } from "~/api/types";
import ModalScheduled from "~/pages/posts/components/ModalScheduled.vue";

const [modalScheduled, openModalScheduled, closeModalScheduled] = useBoolean();

const { form, submit } = useForm("/api/posts", "post", {
	access: PostAccess.Public,
	scheduledAt: undefined,
	content: "",
}, () => {}, true);

const files = ref<File[]>([]);

const postPreview = computed<Post>(() => ({
	content: form.value.content,
	commentsCount: Math.floor(Math.random() * 100),
	likesCount: Math.floor(Math.random() * 100),
	createdAt: new Date().toLocaleString(),
	access: form.value.access,
} as Post));
</script>

<template>
  <NuxtLayout name="feed">
    <Tabs value="0">
      <TabList>
        <Tab value="0">
          Escrever
        </Tab>
        <Tab value="1">
          Pré-visualizar
        </Tab>
        <Tab value="2">
          Agendados
        </Tab>
      </TabList>
      <TabPanels>
        <TabPanel value="0">
          <Editor v-model="form.content" editor-style="height: 320px" class="mb-3" />
          <FilePicker
            v-model="files"
            label="Selecione arquivos para a postagem"
            multiple
            accept="image/*"
            class="mb-3"
          />
          <SelectOptions
            v-model="form.access"
            :options="PostAccess"
            label="Selecione a visibilidade"
          />
          <ModalScheduled
            v-model:visible="modalScheduled"
            @close="closeModalScheduled"
          />
          <div class="flex justify-content-end mt-3 gap-2">
            <Button
              label="Agendar"
              @click="openModalScheduled"
            />
            <Button
              label="Postar"
              @click="submit"
            />
          </div>
        </TabPanel>
        <TabPanel value="1">
          <Post
            :post="postPreview"
            :files="files"
          />
        </TabPanel>
        <TabPanel value="2">
          <p>Agendados</p>
        </TabPanel>
      </TabPanels>
    </Tabs>
  </NuxtLayout>
</template>

<style>

</style>
