<script setup lang="ts">


let login = reactive({
    username: '',
    password: ''
})

let error = ref('')

function usernameIsValid(): boolean {
    return true
}

async function logar() {
    const { data } = await useFetch(`https://localhost:7179/login`, {
        method: 'POST',
        body: login
    })

    console.log(data)
}

</script>
<template>
    <div class="flex justify-center items-center m-5">
        <UCard class="w-56 h-56 bg-black">
            <UForm :state="login" class="space-y-4" @submit="logar">
                <UFormGroup label="Email" name="email">
                    <UInput v-model="login.username">
                        <template #leading>
                            <UAvatar src="https://avatars.githubusercontent.com/u/739984?v=4" size="3xs" />
                        </template>
                    </UInput>
                </UFormGroup>

                <UFormGroup label="Password" name="password">
                    <UInput v-model="login.password" type="password" />
                </UFormGroup>

                <UButton type="submit">
                    Submit
                </UButton>
            </UForm>
        </UCard>
    </div>
</template>
<style>

</style>