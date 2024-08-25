<script setup lang="ts">

interface IUserLogin {
    email: string;
    password: string;
}

const { form, errors, submit } = useForm<IUserLogin>({}, 'POST', 'api/auth/login');

</script>
<template>
    <div class="flex justify-content-center align-items-center h-screen">
        <Card style="width: 25rem; overflow: hidden">
            <template #title>Login</template>
            <template #subtitle>Digite seu email e senha para fazer login</template>
            <template #content>
                <InputGroup>
                    <InputGroupAddon>
                        <i class="pi pi-user" />
                    </InputGroupAddon>
                    <InputText v-model="form.email" placeholder="Email" />
                </InputGroup>
                <FormError :errors="errors" :keys="['USER', 'EMAIL']" />
                <InputGroup class="mt-5">
                    <InputGroupAddon>
                        <i class="pi pi-lock" />
                    </InputGroupAddon>
                    <Password v-model="form.password" toggle-mask :feedback="false" placeholder="Password" />
                </InputGroup>
                <FormError :errors="errors" :keys="['PASSWORD']" />
            </template>
            <template #footer>
                <div class="flex gap-3 mt-1">
                    <Button label="Enviar" class="w-full" @click="submit" />
                </div>
            </template>
        </Card>
    </div>
</template>