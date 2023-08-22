<script setup lang="ts">
import { UserLoginRequest } from 'interfaces/user/user';

let login = reactive<UserLoginRequest>({
    email_or_username: '',
    password: ''
})


</script>
<template>
    <div class="login form-center">
        <div class="login-main">
            <div class="login-header">
                <h2>Login</h2>
            </div>
            <div class="login-content">
                <form>
                    <div class="mb-3">
                        <label for="username" class="form-label">Username ou Email</label>
                        <input type="text" class="form-control" id="username" v-model="login.email_or_username" />

                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Senha</label>
                        <input type="password" class="form-control" id="password" v-model="login.password" />
                    </div>
                    <button type="submit" class="btn btn-primary">Entrar</button>
                </form>
            </div>
        </div>
    </div>
</template>
<style>
.form-center {
    display: flex;
    align-items: center;
    justify-content: center;
    height: 100vh;
}

.form-register {
    width: 50vh;
    margin: 0 auto;
}

.form-username-buttons {
    margin-right: 0 auto;
}
.login-main{
    width: 50vh;
    height: 50vh;
    border: 1px solid #ccc;
    border-radius: 5px;
    padding: 2%;
}
</style>