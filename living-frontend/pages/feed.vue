<script setup>
import Post from '@/components/feed/posts/Post.vue';
import FeedLayout from '@/components/layouts/FeedLayout.vue';

definePageMeta({
    middleware: 'auth'
})

</script>

<template>
    <FeedLayout>
        <h1>Welcome to the feed</h1>
        <div class="posts">
            <Post v-for="post in Array(5)" />
        </div>
    </FeedLayout>
</template>