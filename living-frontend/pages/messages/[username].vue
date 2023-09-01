<script setup lang="ts">
import MessageLayout from '@/components/layouts/MessageLayout.vue';
import Message from '@/components/messages/Message.vue';
import { Post } from 'interfaces/posts/post';
import { MessageRequest } from 'interfaces/messages/message';


const route = useRoute()
let username = route.params.username

let mensagem = reactive<MessageRequest>({
    content: '',
})

const { pending, data: posts } = await useLazyFetch<Array<Post>>(`https://localhost:7179/messages/${username}`, {
    method: 'GET',
    server: false,
    headers: {
        'Autorization': `Bearer ${useCookie('token')}`
    }
})

console.log(posts)

async function sendMessage() {


    const { data } = await useFetch<Array<Post>>(`https://localhost:7179/messages/send`, {
        method: 'POST',
        server: false,
        headers: {
            'Autorization': `Bearer ${useCookie('token')}`
        },
        body: {
            message: mensagem.content,
        }
    })
}


</script>
<template>
    <MessageLayout>
        <div v-if="pending">
            <Loader :loading="true" />
        </div>
        <div v-else class="h-100">
            <div class="messages">
                <Message />
                <Message />
            </div>
            <form @submit.prevent="sendMessage" class="d-flex">
                <input type="text" class="form-control" v-model="mensagem.content" required
                    placeholder="Digite sua mensagem" />
                <button type="submit" class="btn btn-primary">Enviar</button>
            </form>
        </div>
    </MessageLayout>
</template>
<style>
.messages {
    overflow: auto;
    height: 95%;
    width: 100%;
}
</style>