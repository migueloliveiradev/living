<script setup lang="ts">
import { UserRequest } from 'interfaces/user/user';

let step = ref(1)

let form = reactive<UserRequest>({
    name: '',
    username: '',
    email: '',
    bio: '',
    birth_date: '',
    password: '',
    password_confirmation: '',
    banner: new File([''], 'banner.png', { type: 'image/png' }),
    photo: new File([''], 'avatar.png', { type: 'image/png' })
})

function inputPhoto(event: any) {
    form.photo = event.target.files[0]
}

function inputBanner(event: any) {
    form.banner = event.target.files[0]
}

</script>
<template>
    <div class="container-page">
        <div>
            <ClientOnly>
                <div class="">
                    <ProfileRegister :user="form" />
                </div>
                <div className="form-register form-center" v-if="step === 1">
                    <form className='form-register'>
                        <div className="form-header">
                            <h1>Faça seu registro</h1>
                        </div>
                        <div className="mb-3">
                            <label for="name" className="form-label">Nome</label>
                            <input type="text" className="form-control" id="name" required v-model="form.name" />
                        </div>
                        <div className="mb-3">
                            <label for="username" className="form-label">Username</label>
                            <input type="text" className="form-control" id="username"
                                placeholder='Esse será usuario unico que aparecerá para os outros usuários' required
                                v-model="form.username" />
                        </div>
                        <div className="mb-3">
                            <label for="email" className="form-label">Email</label>
                            <input type="email" className="form-control" id="email" required v-model="form.email" />
                        </div>
                        <div className="mb-3">
                            <label for="password" className="form-label">Senha</label>
                            <input type="password" className="form-control" id="password" required
                                v-model="form.password" />
                        </div>
                        <div className="mb-3">
                            <label for="password_confirmed" className="form-label">Confirme a senha</label>
                            <input type="password" className="form-control" id="password_confirmation" required
                                v-model="form.password_confirmation" />
                        </div>
                        <button type="submit" className="btn btn-primary" @click="step = 2">Continuar</button>
                    </form>
                </div>
                <div v-if="step === 2">
                    <div className="form-register form-center">
                        <form className='form-register'>
                            <div className="form-header">
                                <h1>Faça seu registro</h1>
                            </div>
                            <div className="mb-3">
                                <label for="bio" className="form-label">Bio</label>
                                <input type="text" className="form-control" id="bio" required v-model="form.bio" />
                            </div>
                            <div className="mb-3">
                                <label for="birth_date" className="form-label">Data de nascimento</label>
                                <input type="date" className="form-control" id="birth_date" required
                                    v-model="form.birth_date" />
                            </div>
                            <div className="mb-3">
                                <label for="banner" className="form-label">Banner</label>
                                <input type="file" className="form-control" id="banner" required @change="inputBanner" />
                            </div>
                            <div className="mb-3">
                                <label for="photo" className="form-label">Foto</label>
                                <input type="file" className="form-control" id="photo" required @change="inputPhoto" />
                            </div>
                            <button type="submit" className="btn btn-primary" @click="step = 3">Continuar</button>
                        </form>
                    </div>
                </div>
            </ClientOnly>
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
</style>