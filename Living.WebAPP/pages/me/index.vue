<script lang="ts" setup>
import { ref } from 'vue';
import Card from 'primevue/card';
import Button from 'primevue/button';
import Avatar from 'primevue/avatar';
import Divider from 'primevue/divider';

const profileData = ref({
    name: 'Miguel Oliveira',
    username: 'migueloliveira',
    bio: 'Bio interesante.',
    createdAt: '01/01/2023',
    followers: 150,
    following: 100,
});
</script>

<template>
    <NuxtLayout name="feed">
        <div class="flex justify-content-center p-4">
            <Card class="w-full">
                <template #title>
                    <div class="flex align-items-center mb-3">
                        <Avatar image="https://via.placeholder.com/350" shape="circle" size="large" class="mr-3" />
                        <div class="flex-grow-1">
                            <h2 class="m-0">{{ profileData.name }}</h2>
                            <p class="text-sm text-500">@{{ profileData.username }}</p>
                        </div>
                        <div class="flex gap-2">
                            <Button label="Seguir" icon="pi pi-user-plus" class="p-button-rounded p-button-outlined" />
                            <Button label="Editar Perfil" icon="pi pi-pencil" class="p-button-rounded"
                                severity="secondary" />
                        </div>
                    </div>
                </template>
                <template #content>
                    <Divider class="my-2" />
                    <div class="text-left">
                        <p class="text-base mb-2">{{ profileData.bio }}</p>
                    </div>
                    <Divider class="my-2" />
                    <div class="flex justify-content-around surface-border py-3">
                        <div class="text-center">
                            <span class="text-xl font-bold">{{ profileData.followers }}</span>
                            <p class="text-sm text-600">Seguidores</p>
                        </div>
                        <div class="text-center">
                            <span class="text-xl font-bold">{{ profileData.following }}</span>
                            <p class="text-sm text-600">Seguindo</p>
                        </div>
                    </div>
                </template>
                <template #footer>
                    <div class="flex justify-content-end flex-wrap">
                        <p class="text-sm text-500">Membro desde: {{ profileData.createdAt }}</p>
                    </div>
                </template>
            </Card>
        </div>
    </NuxtLayout>
</template>
