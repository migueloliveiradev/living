import { createConfigForNuxt } from '@nuxt/eslint-config/flat'

export default createConfigForNuxt({
}).prepend({
    rules: {
        "vue/max-attributes-per-line": ["warn", {
            "singleline": {
                "max": 4
            },
            "multiline": {
                "max": 1
            }
        }],
        "vue/prop-name-casing": ["error", "camelCase"]
    },

})