import { createConfigForNuxt } from '@nuxt/eslint-config/flat'

export default createConfigForNuxt({
}).prepend({
    rules: {
        "vue/max-attributes-per-line": ["error", {
            "singleline": {
                "max": 4
            },
            "multiline": {
                "max": 1
            }
        }]
    }
})