<script setup lang="ts">
import { UserRequest } from 'interfaces/user/user';

const props = defineProps({
    user: Object as PropType<UserRequest>
})

let followers_count_random = Math.floor(Math.random() * 2000)
let following_count_random = Math.floor(Math.random() * 500)

</script>
<template>
    <div>
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
                        <p class="m-0">{{ user?.name || "Usuario" }}</p>
                        <p class="username m-0">@{{ (user?.username || "usuario") }}</p>
                    </div>
                </div>
                <div class="profile-body-right">
                    <div class="profile-body-right-numbers mb-1">
                        <div class="d-flex justify-content-around">
                            <p class="m-0">{{ followers_count_random }}</p>
                            <p class="m-0">Seguidores</p>
                        </div>
                        <div class="d-flex justify-content-around">
                            <p class="m-0">{{ following_count_random }}</p>
                            <p class="m-0">Seguindo</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="profile-content mt-3">
                <div class="profile-content-header w-50" v-if="user?.bio">
                    <p class="m-3"> {{ user.bio }}</p>
                </div>
                <div class="profile-content-body" v-if="user?.birth_date">
                    <div class="m-3 ">
                        <p class="m-0">Membro desde 2021</p>
                        <p class="m-0">Nascimento 11 de setembro de 2001</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
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