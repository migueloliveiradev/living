<script setup lang="ts">
import Loader from '@/components/loader/Loader.vue';
import FormError from '@/components/form/FormError.vue';
import { UserRegisterResponse, UserRequest } from 'interfaces/user/user';

let step = ref(1)

let form = reactive<UserRequest>({
    name: '',
    username: '',
    email: '',
    bio: '',
    birth_date: '',
    password: '',
    password_confirmation: ''
})

let show_password = ref(false)
let loading = ref(false)
let username_avaliable = ref(true)
let user_register = ref<UserRegisterResponse>({
    errors: [],
    success: false,
    token: '',
})

async function checkUsernameAvailable() {
    const { data: avaliable } = await useFetch(`https://localhost:7179/user/check_username_available`,
        {
            params: {
                username: form.username
            }
        })
    console.log(avaliable.value)
    username_avaliable.value = avaliable.value
}

async function cadastrarUsuario() {
    loading.value = true

    const { data, error } = await useFetch<UserRegisterResponse>(`https://localhost:7179/register`, {
        method: 'POST',
        body: form,
        onResponse: (response) => {
            user_register.value.errors = (response.response._data as UserRegisterResponse).errors
        }
    })

    console.log(data)
    console.log(error)


    if (user_register.value.success) {
        const token = useCookie('token')
        token.value = user_register.value.token
        step.value = 2
    }

    loading.value = false
}

</script>
<template>
    <div class="container-page">
        <Loader :loading="loading" />
        <div>

            <div class="">
                <ProfileRegister :user="form" />
            </div>
            <div class="div-form-register form-center" v-if="step === 1">
                <form class='form-register'>
                    <div class="form-header">
                        <h3>Faça seu registro</h3>
                    </div>
                    <div class="mb-3">
                        <label for="name" class="form-label">Nome</label>
                        <input type="text" class="form-control" id="name" required v-model="form.name" />
                        <FormError :errors="user_register?.errors.name" />
                    </div>
                    <div class="mb-3">
                        <label for="username" class="form-label">Username</label>
                        <input type="text" class="form-control" id="username"
                            placeholder='Esse será usuario unico que aparecerá para os outros usuários' required
                            v-model="form.username" @keydown.space.prevent minlength="5" maxlength="15"
                            @input="checkUsernameAvailable" />
                        <p class="form-text text-danger" v-if="!username_avaliable">Username não disponivel</p>
                        <FormError :errors="user_register?.errors.username" />
                    </div>
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="email" class="form-control" id="email" required v-model="form.email" />
                        <FormError :errors="user_register?.errors.email" />
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Senha</label>
                        <div class="input-group">
                            <input :type="show_password ? 'password' : 'text'" class="form-control" id="password" required
                                v-model="form.password" />
                            <span class="input-group-text" @click="show_password = !show_password">
                                <font-awesome-icon
                                    :icon="show_password ? 'fa-regular fa-eye-slash ' : 'fa-regular fa-eye'" />
                            </span>
                        </div>
                        <FormError :errors="user_register?.errors.password" />
                    </div>
                    <div class="mb-3">
                        <label for="password_confirmed" class="form-label">Confirme a senha</label>
                        <input type="password" class="form-control" id="password_confirmation" required
                            v-model="form.password_confirmation" />
                        <FormError :errors="user_register?.errors.password_confirmed" />
                    </div>
                    <button type="submit" class="btn btn-primary" @click="cadastrarUsuario">Continuar</button>
                </form>
            </div>
            <div v-if="step === 2">
                <div class="form-register form-center">
                    <form class='form-register'>
                        <div class="form-header">
                            <h3>Agora conte um pouco mais sobre você</h3>
                        </div>
                        <div class="mb-3">
                            <label for="bio" class="form-label">Bio</label>
                            <textarea type="text" class="form-control" id="bio" required v-model="form.bio" />
                        </div>
                        <div class="mb-3">
                            <label for="birth_date" class="form-label">Data de nascimento</label>
                            <input type="date" class="form-control" id="birth_date" required v-model="form.birth_date" />
                        </div>
                        <button type="submit" class="btn btn-primary">Cadastrar e
                            continuar</button>
                    </form>
                </div>
            </div>

            <div v-if="step === 3">
                <h3>Agora é a hora de enviar seu banner e foto de perfil</h3>
                <div class="mb-3">
                    <label for="banner" class="form-label">Banner</label>
                    <input type="file" class="form-control" id="banner" required />
                </div>
                <div class="mb-3">
                    <label for="photo" class="form-label">Foto</label>
                    <input type="file" class="form-control" id="photo" required />
                </div>
            </div>

        </div>
    </div>
</template>
<style scoped>
.form-register {
    margin-bottom: 10%;
    padding: 3%;
}

.container-page {
    display: flex;
    justify-content: center;
    margin-left: 20%;
    margin-right: 20%;
}

.security {
    color: green;
}
</style>