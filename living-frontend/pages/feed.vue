<script setup lang="ts">
import PostComponent from '@/components/feed/posts/Post.vue';
import FeedLayout from '@/components/layouts/FeedLayout.vue';
import { Post } from 'interfaces/posts/post';

definePageMeta({

})

let { pending, data: posts } = await useLazyFetch<Array<Post>>(`https://localhost:7179/timeline/get`, {
    server: false
})

</script>

<template>
    <FeedLayout>
        <h3>Bem Vindo a seu feed</h3>
        <Loader :loading="pending" />
        <div class="posts">
            <PostComponent v-for="post in posts" :post="post" />
        </div>
    </FeedLayout>
</template>