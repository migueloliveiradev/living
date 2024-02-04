<script setup lang="ts">

interface IUserLogin {
    email: string;
    password: string;
}

const { form, errors, submit, data } = useForm<IUserLogin>({
    email: '',
    password: '',
}, 'POST', 'api/auth/login');

</script>
<template>
    <div class="flex justify-content-center align-items-center h-screen">
        <Card style="width: 25rem; overflow: hidden">
            <template #title>Login</template>
            <template #subtitle>Digite seu email e senha para fazer login</template>
            <template #content>
                <InputGroup>
                    <InputGroupAddon>
                        <i class="pi pi-user"></i>
                    </InputGroupAddon>
                    <InputText placeholder="Email" v-model="form.email" />
                </InputGroup>
                <FormError :errors="errors" :keys="['USER', 'EMAIL']" />
                <InputGroup class="mt-5">
                    <InputGroupAddon>
                        <i class="pi pi-lock" />
                    </InputGroupAddon>
                    <Password toggleMask :feedback=" false" v-model=" form.password " placeholder="Password" />
                </InputGroup>
                <FormError :errors="errors" :keys="['PASSWORD']" />
            </template>
            <template #footer>
                <div class="flex gap-3 mt-1">
                    <Button label="Enviar" class="w-full" @click=" submit " />
                </div>
            </template>
        </Card>
    </div>
</template>