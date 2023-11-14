<script setup lang="ts">

const props = defineProps({
    errors: Array
})

</script>
<template>
    <div class="form-error mt-1" v-if="errors?.length !== 0">
        <p class="error" v-for="error in errors" :key="error">
            {{ error }}
        </p>
    </div>
</template>