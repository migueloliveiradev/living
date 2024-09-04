const languages = ref([
	{ option: "Portugues", code: "pt-br" },
	{ option: "Inglês", code: "en" },
]);

export function useLanguage() {
	const { t, locale } = useI18n({
		useScope: "local",
	});

	function text(code: string) {
		return t(code);
	}

	return {
		languages,
		locale,
		text,
	};
}
