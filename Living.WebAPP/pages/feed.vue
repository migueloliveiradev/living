<script setup lang="ts">
import PostComponent from '@/components/feed/posts/Post.vue';
import FeedLayout from '@/components/layouts/FeedLayout.vue';
import type { Post } from '@/interfaces/posts/post';

let posts: Post[] = [
    {
        id: 1,
        content: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam, voluptatum.',
        created_at: '2021-08-01 12:00:00',
        likes: [],
        likes_count: 0,
        user: {
            id: 1,
            name: 'John Doe',
            username: 'johndoe',
            photo_url: 'https://i.pravatar.cc/50?u=johndoe',
            email: 'johndoe@example.com',
            banner_url: 'https://example.com/banner.jpg',
            bio: 'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
            created_at: '2021-08-01 10:00:00',
            birth_date: '1990-01-01',
            followers: [],
            following: [],
            groups: [],
            likes: [],
            posts: [],
            updated_at: '2021-08-01 10:00:00',
        },
        user_id: 1,
    }
]

</script>

<template>
    <FeedLayout>
        <h3>Bem Vindo a seu feed</h3>
        <Loader :loading="false" />
        <div class="posts">
            <PostComponent v-for="post in posts" :post="post" />
        </div>
    </FeedLayout>
</template>