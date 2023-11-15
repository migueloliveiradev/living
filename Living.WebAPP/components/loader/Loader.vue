<script setup lang="ts">

const props = defineProps({
    loading: Boolean
})

</script>
<template>
    <div class="loader-container" v-if="loading">
        <div class="loader">
        </div>
    </div>
</template>
<style>
.loader-container {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    background: rgba(0, 0, 0, 0.5);
}

.loader {
    width: 100px;
    height: 100px;
    border-radius: 50%;
    display: inline-block;
    border-top: 3px solid #FFF;
    border-right: 3px solid transparent;
    box-sizing: border-box;
    animation: rotation 1s linear infinite;
}

@keyframes rotation {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}

.loader svg {
    width: 100%;
    height: 100%;
}
</style>