<script setup>
</script>
<template>
    <div class="container-layout">
        <div class="sidebar">
            <div class="sidebar-header ">
                <h2 class="text-center">Living</h2>
            </div>
            <div class="sidebar-content">
                <ul class="list-group list-group-flush mt-5 buttons-nav">
                    <NuxtLink to="/feed" class='list-group-item text-light p-3 button-nav m-2 d-flex pb-0'>
                        <div>
                            <font-awesome-icon icon="fa-solid fa-house" />
                        </div>
                        <p class='ms-2'>Pagina Inicial</p>
                    </NuxtLink>

                    <NuxtLink to="/feed" class='list-group-item text-light p-3 button-nav m-2 d-flex pb-0'>
                        <div>
                            <font-awesome-icon icon="fa-solid fa-magnifying-glass" />
                        </div>
                        <p class='ms-2'>Explorar</p>
                    </NuxtLink>
                    <NuxtLink to="/feed" class='list-group-item text-light p-3 button-nav m-2 d-flex pb-0'>
                        <div>
                            <font-awesome-icon icon="fa-solid fa-magnifying-glass" />
                        </div>
                        <p class='ms-2'>Notificações</p>
                    </NuxtLink>

                    <NuxtLink to="/feed" class='list-group-item text-light p-3 button-nav m-2 d-flex pb-0'>
                        <div>
                            <font-awesome-icon icon="fa-solid fa-users" />
                        </div>
                        <p class='ms-2'>Grupos</p>
                    </NuxtLink>
                    <NuxtLink to="/messages" class='list-group-item text-light p-3 button-nav m-2 d-flex pb-0'>
                        <div>
                            <font-awesome-icon icon="fa-solid fa-message" />
                        </div>
                        <p class='ms-2'>Mensagens</p>
                    </NuxtLink>
                </ul>
            </div>
            <NuxtLink to="/me" class='sidebar-footer mb-2'>
                <div class='m-3 d-flex align-items-center'>
                    <img class="sidebar-footer-icon" src="/eimigueloliveir.png" alt="avatar perfil" width="50"
                        height="50" />
                    <p class='m-0 ms-2'>Miguel Oliveira</p>
                </div>
            </NuxtLink>
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
}
</style>