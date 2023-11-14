<script setup lang="ts">
import FriendsOnline from '@/components/messages/FriendsOnline.vue';
import FeedLayout from './FeedLayout.vue';


</script>
<template>
    <FeedLayout>
        <div class=" w-100 h-100">
            <div class="d-flex">
                <div class="friends">
                    <FriendsOnline />
                    <input type="text" class="form-control" placeholder="Pesquisar amigos" />
                    <MessagesHistory />
                    <MessagesHistory />
                    <MessagesHistory />
                </div>
                <div class="chat">
                    <slot />
                </div>
            </div>
        </div>
    </FeedLayout>
</template>