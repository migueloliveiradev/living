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
                        <p class="m-0">Miguel Oliveira </p>
                        <p class="m-0 ms-1 username"> - @eimigueloliveir</p>
                    </div>
                </div>
                <div class="post-header-date">
                    <p class="m-0 me-3">há 1 hora</p>
                </div>
            </div>
            <hr />
            <p class="m-0 mb-1">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum
                has been the industrys
                standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to
                make a type specimen book. It has survived not only five centuries, but also the leap into electronic
                typesetting,
                remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets
                containing
                Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including
                versions of Lorem Ipsum. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in
                a
                piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin
                professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur,
                from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the
                undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et </p>
        </div>
        <div class="post-footer mt-3">
            <div class="post-footer-actions d-flex">
                <div class="post-footer-actions-like d-flex align-items-center">
                    <font-awesome-icon icon="fa-regular fa-heart" size="xl" />
                    <p class="m-0 ms-1">27</p>
                </div>
                <div class="post-footer-actions-comment d-flex align-items-center">
                    <font-awesome-icon icon="fa-regular fa-comment" size="xl" />
                    <p class="m-0 ms-1">69</p>
                </div>
                <div class="post-footer-actions-share d-flex align-items-center">
                    <font-awesome-icon icon="fa-solid fa-share" />
                    <p class="m-0 ms-1">Compartilhar</p>
                </div>
                <div class="post-footer-date">
                    <p class="m-0">11/07/2023 - 11:25</p>
                </div>
            </div>
        </div>
    </div>
</template>