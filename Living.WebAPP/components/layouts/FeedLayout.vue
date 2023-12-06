<script setup lang="ts">

import type { VerticalNavigationLink } from '@nuxt/ui/dist/runtime/types';


const links: VerticalNavigationLink[] = [{
    label: 'Pagina Inicial',
    icon: 'i-heroicons-home',
    to: '/feed'
}, {
    label: 'Explorar',
    icon: 'i-heroicons-chart-bar',
    to: '/feed'
}, {
    label: 'Notificações',
    icon: 'i-heroicons-command-line',
    to: '/feed'
},
{
    label: 'Grupos',
    icon: 'i-heroicons-command-line',
    to: '/feed'
},
{
    label: 'Mensagens',
    icon: 'i-heroicons-command-line',
    to: '/feed'
},
{
    label: 'Perfil',
    avatar: {
        src: 'https://avatars.githubusercontent.com/u/739984?v=4',
        alt: 'Avatar',
        size: 'md'
        
    },
    badge: 100,
    to: '/me'
},
]

</script>
<template>
    <div class="container-layout">
        <div>
            <UVerticalNavigation class="w-38 h-38" :links="links" />
        </div>
        <div class='container-content'>
            <slot />
        </div>
    </div>
</template>
<style>
.sidebar {
    height: 100vh;
    border-radius: 5px;
    position: fixed;
    overflow: hidden;
}

.container-content {
    margin-left: 250px;
    margin-top: 50px;
    margin-right: 50px;
}

.sidebar-footer {
    position: fixed;
    bottom: 0;
    margin-bottom: auto;
    align-items: stretch;
    border-radius: 25px;
    border: 2px solid #313030;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    min-width: 250px;
    margin-left: -35px;
}

.sidebar-footer-post {
    margin-bottom: 20px;
}

.feed-main {

    margin-top: 50px;
    margin-right: 50px;
}

.list-group-item {
    background-color: transparent !important;
    border: none !important;
}

.btn-new-post {
    border-radius: 20px !important;
    padding-left: 10px !important;
    padding-right: 10px !important;
    width: 130px;
    height: 50px;
}

.post {
    border-radius: 2rem;
    background-color: #0f0f0f;
    margin-bottom: 20px;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.post-header-user-img {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    margin-right: 10px;
}

.post-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
    padding: 10px 10px 0 0;
    border-radius: 2rem;
}

.post-header-user-name {
    font-size: 1.2rem;
    font-weight: 600;
    color: #fff;
}

.post-header-user-name .username {
    font-size: 1rem;
    font-weight: 400;
    color: #aaa;
}

.post-content {
    padding: 10px 20px;
    border-radius: 2rem;
    background-color: #181818;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.post-footer {
    padding: 10px 20px;
    border-radius: 2rem;
    background-color: #181818;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);

}

.post-footer-actions {
    display: flex;
    justify-content: flex-start;
    align-items: center;
}

.post-footer-actions div {
    margin-right: 20px;
}

.post-footer-date {
    margin-left: auto;
}

.sidebar-footer-icon {
    border-radius: 50%;
}

.button-nav {
    transition: all 0.3s ease-in-out;
    border-radius: 20px !important;
    padding-left: 10px !important;
    padding-right: 10px !important;
}

.button-nav:hover {
    background-color: #4d4c4c !important;
}

.buttons-nav {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    margin-bottom: 20px;
    padding: 10px 0 0 0;
}

.modal-content {
    background-color: #181818;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.container-layout {
    margin-left: 15vh;
    margin-right: 15vh;
    display: flex;

}
</style>