<script setup  lang="ts">
import { Post } from '~/interfaces/posts/post'

const props = defineProps({
    post: Object as PropType<Post>,
})
</script>
<template>
    <div class="post">
        <div class="post-content">
            <div class="post-header">
                <div class="post-header-user d-flex">
                    <img src="/eimigueloliveir.png" class="post-header-user-img" width={50} height={50} alt="user" />
                    <div class="post-header-user-name d-flex align-items-center">
                        <p class="m-0">{{ post?.user?.name }}</p>
                        <p class="m-0 ms-1 username"> - @{{ post?.user?.username }}</p>
                    </div>
                </div>
                <div class="post-header-date">
                    <p class="m-0 me-3">há 1 hora</p>
                </div>
            </div>
            <hr />
            <p class="m-0 mb-1">{{ post?.content }}</p>
        </div>
        <div class="post-footer mt-3">
            <div class="post-footer-actions d-flex">
                <div class="post-footer-actions-like d-flex align-items-center">
                    <font-awesome-icon icon="fa-regular fa-heart" size="xl" />
                    <p class="m-0 ms-1">{{ post?.likes_count }}</p>
                </div>
                <div class="post-footer-actions-comment d-flex align-items-center">
                    <font-awesome-icon icon="fa-regular fa-comment" size="xl" />
                    <p class="m-0 ms-1">0</p>
                </div>
                <div class="post-footer-actions-share d-flex align-items-center">
                    <font-awesome-icon icon="fa-solid fa-share" />
                    <p class="m-0 ms-1">Compartilhar</p>
                </div>
                <div class="post-footer-date">
                    <p class="m-0">{{ post?.created_at }}</p>
                </div>
            </div>
        </div>
    </div>
</template>