<script lang="ts" setup>
import type { Post } from "~/api/types";

const post = computed<Post>(() => ({
	content: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
	commentsCount: Math.floor(Math.random() * 100),
	likesCount: Math.floor(Math.random() * 100),
	createdAt: new Date().toLocaleString(),
} as Post));
</script>

<template>
  <NuxtLayout name="feed">
    <Post
      v-for="number in Array(5)"
      :key="number"
      class="mt-2"
      :post="post"
      :files="[]"
    />
  </NuxtLayout>
</template>
