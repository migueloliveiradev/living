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
			"vue/html-indent": [
				"error",
				2,
				{
					attribute: 1,
					baseIndent: 1,
					closeBracket: 0,
					alignAttributesVertically: false,
				},
			],
			"vue/block-order": ["error", {
				order: ["script", "template", "style"],
			}],
			"vue/block-lang": ["error",
				{
					script: {
						lang: "ts",
					},
				},
			],
		},
	},
);
