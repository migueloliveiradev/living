<script setup>
import Post from 'components/feed/posts/Post.vue';


definePageMeta({
    middleware: 'auth'
})

</script>

<template>
    <div>
        <h1>Welcome to the feed</h1>
        <Post />
    </div>
</template>