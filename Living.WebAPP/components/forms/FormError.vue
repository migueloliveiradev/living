<script setup lang="ts">
import type { Notification } from '~/composables/useApi';

const props = defineProps<{
    errors: Notification;
    keys: string[];
}>();

const { t } = useI18n({
    useScope: 'local'
});

</script>
<template>
    <div v-if="errors" class="mt-2">
        <div v-for="(codes, key) in errors">
            <div v-if="keys.includes(key as unknown as string)">
                <div v-for="code in codes">
                    <div class="text-red-500">{{ t(`${key}.${code}`) }}</div>
                </div>
            </div>
        </div>
    </div>
</template>

<i18n lang="json">
{
    "pt-br": {
        "USER": {
            "NOT_FOUND": "Usuário não encontrado"
        },
        "EMAIL": {
            "IS_REQUIRED": "Email é obrigatório",
            "IS_EMAIL": "Email inválido"
        },
        "PASSWORD": {
            "IS_REQUIRED": "Senha é obrigatória"
        }
    },
    "en": {
        "USER": {
            "NOT_FOUND": "User not found"
        },
        "EMAIL": {
            "IS_REQUIRED": "Email is required",
            "IS_EMAIL": "Invalid email"
        },
        "PASSWORD": {
            "IS_REQUIRED": "Password is required"
        }
    }
}
</i18n>