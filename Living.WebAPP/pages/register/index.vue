<script setup lang="ts">
const { form, errors, submit } = useForm("/api/auth/register", "post", {}, () => {
	navigateTo("/login");
});
</script>

<template>
  <NuxtLayout name="home">
    <form @submit.prevent="submit">
      <div class="flex justify-content-center align-items-center h-screen">
        <Card style="width: 25rem; overflow: hidden">
          <template #title>
            Registro
          </template>
          <template #subtitle>
            Preencha os seguintes dados para fazer seu cadastro
          </template>
          <template #content>
            <InputGroup class="mt-3">
              <InputGroupAddon>
                <i class="pi pi-user" />
              </InputGroupAddon>
              <InputText
                v-model="form.name"
                placeholder="Miguel Oliveira"
                required
              />
            </InputGroup>
            <small class="text-muted">Seu nome</small>
            <FormError
              :errors="errors"
              :keys="['NAME']"
            />
            <InputGroup class="mt-3">
              <InputGroupAddon>
                <i class="pi pi-user" />
              </InputGroupAddon>
              <InputText
                v-model="form.username"
                placeholder="migueloliveira"
                required
              />
            </InputGroup>
            <small class="text-muted">Seu nome de usuário</small>
            <FormError
              :errors="errors"
              :keys="['USERNAME']"
            />
            <InputGroup class="mt-3">
              <InputGroupAddon>
                <i class="pi pi-user" />
              </InputGroupAddon>
              <InputText
                v-model="form.email"
                placeholder="contato@migueloliveira.com"
                required
              />
            </InputGroup>
            <small class="text-muted">Seu email</small>
            <FormError
              :errors="errors"
              :keys="['USER', 'EMAIL']"
            />
            <InputGroup class="mt-3">
              <InputGroupAddon>
                <i class="pi pi-lock" />
              </InputGroupAddon>
              <Password
                v-model="form.password"
                toggle-mask
                :feedback="false"
                placeholder="oliveira@123!"
                required
              />
            </InputGroup>
            <small class="text-muted">Sua senha</small>
            <FormError
              :errors="errors"
              :keys="['PASSWORD']"
            />
          </template>
          <template #footer>
            <div class="flex gap-3 mt-1">
              <Button
                label="Enviar"
                class="w-full"
                type="submit"
              />
            </div>
          </template>
        </Card>
      </div>
    </form>
  </NuxtLayout>
</template>
