import withNuxt from "./.nuxt/eslint.config.mjs";

export default withNuxt(
	{
		rules: {
			"@stylistic/quotes": ["error", "double"],
			"no-console": "error",
			"vue/max-attributes-per-line": ["warn", {
				singleline: {
					max: 4,
				},
				multiline: {
					max: 1,
				},
			}],
			"vue/prop-name-casing": ["error", "camelCase"],
		},
		ignores: [
			"api/schema.d.ts",
		],
	},
);
