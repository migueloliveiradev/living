<script setup>
import FeedLayout from '@/components/layouts/FeedLayout.vue';

definePageMeta({
    middleware: 'profile'
})

const route = useRoute()
let username = route.params.username

</script>


<template>
    <FeedLayout>
        <div class="profile">
            <div class="profile-header">
                <img class="banner-profile" src="/banner.png" alt="banner perfil" width="1500" height="200" />
            </div>
            <div class="profile-body d-flex justify-content-between">
                <div class="profile-body-left d-flex">
                    <div class="profile-body-left-avatar">
                        <img class="avatar-profile" src="/eimigueloliveir.png" alt="avatar perfil" width="180"
                            height="180" />
                    </div>
                    <div class="profile-body-left-name">
                        <p class="m-0">Miguel Oliveira</p>
                        <p class="username m-0">@{{ username }}</p>
                    </div>
                </div>
                <div class="profile-body-right">
                    <div class="profile-body-right-friend">
                        <button class="btn btn-secondary">Adicionar</button>
                    </div>
                    <div class="profile-body-right-numbers mb-1">
                        <div class="d-flex justify-content-around">
                            <p class="m-0">0</p>
                            <p class="m-0">Amigos</p>
                        </div>
                        <div class="d-flex justify-content-around">
                            <p class="m-0">0</p>
                            <p class="m-0">Grupos</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="profile-content">
                <div class="profile-content-header w-50">
                    <p class="m-3">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                        Ipsum has been the industry standard dummy text ever since the 1500s, when an unknown printer took a
                        galley of type and scrambled it to make a type specimen book. It has survived not only five
                        centuries</p>
                </div>
                <div class="profile-content-body">
                    <div class="m-3 ">
                        <p class="m-0">Membro desde 2021</p>
                        <p class="m-0">Nascimento 11 de setembro de 2001</p>
                    </div>
                </div>
            </div>
        </div>
    </FeedLayout>
</template>
<style>
.banner-profile {
    border-radius: 30px;
    width: 100%;
}

.profile {
    margin-top: 50px;
}

.profile-body,
.profile-content {
    margin-left: 50px;
    margin-right: 50px;
}

.profile-body-left-avatar {
    margin-top: -50px;
}

.avatar-profile {
    border-radius: 50%;
    border: 2px solid #313030;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.profile-body-left-name {
    font-size: 1.5rem;
    margin-left: 20px;
    margin-top: 20px;
}

.profile-body-left-name .username {
    font-size: 1.2rem;
    font-weight: 400;
    color: #aaa;
}

.profile-body-right {
    margin-top: 20px;
    margin-left: 20px;
    border: 1px solid #242424;
    background: rgba(217, 217, 217, 0.00);
    border-radius: 25px;
    min-width: 200px;
}

.profile-body-right-friend {
    margin-top: 20px;
    display: flex;
    justify-content: center;
}

.profile-body-right-numbers {
    margin-top: 40px;
}

.profile-content-header {
    border-radius: 25px;
    border: 1px solid #242424;
    background: rgba(217, 217, 217, 0.00);
}

.profile-content-body {
    margin-top: 20px;
    border: 1px solid #242424;
    background: rgba(217, 217, 217, 0.00);
    border-radius: 25px;
    width: 30%;
}
</style>