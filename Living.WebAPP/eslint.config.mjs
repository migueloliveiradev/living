import { createConfigForNuxt } from '@nuxt/eslint-config/flat'

export default createConfigForNuxt({
}).prepend({
    rules: {
        "vue/max-attributes-per-line": ["error", {
            "singleline": {
                "max": 2
            },
            "multiline": {
                "max": 1
            }
        }]
    }
})