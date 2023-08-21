<script setup>

const route = useRoute()
let username = route.params.username

</script>


<template>
    <div>
        <h1>Welcome to the {{ username }}</h1>
        <AppAlert>
            This is an auto-imported component
        </AppAlert>
    </div>
</template>