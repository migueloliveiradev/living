<script lang="ts" setup>
import type { Post } from "~/api/types";

interface PostComponent {
	post: Post;
	files: File[];
	readonly?: boolean;
}

const { post } = defineProps<PostComponent>();
</script>

<template>
  <div class="card">
    <Fieldset>
      <template #legend>
        <div class="flex items-center pl-2 author">
          <Avatar image="https://avatars.githubusercontent.com/u/87040481" shape="circle" />
          <span class="font-bold p-2">Miguel Oliveira</span>
        </div>
      </template>
      <!-- eslint-disable-next-line vue/no-v-html -->
      <p class="m-0" v-html="post.content" />
      <Divider />
      <div class="footer flex justify-content-between">
        <div class="buttons flex">
          <div class="flex">
            <i class="pi pi-thumbs-up" />
            <span class="font-bold">{{ post.likesCount }}</span> Likes
          </div>
          <div class="flex">
            <i class="pi pi-comment" />
            <span class="font-bold">{{ post.commentsCount }}</span> Comments
          </div>
        </div>
        <label class="font-bold">{{ post.createdAt }}</label>
      </div>
    </Fieldset>
  </div>
</template>

<style lang="css" scoped>
.author {
  border:1px solid var(--p-fieldset-border-color);
  border-radius:var(--p-fieldset-border-radius);
  padding: 5px;
}

.buttons div {
  margin-right: 1rem;
}

.buttons div * {
  margin-right: 0.3rem;
}
</style>
