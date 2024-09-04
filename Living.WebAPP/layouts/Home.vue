<script setup lang="ts">
import type { MenuItem } from "primevue/menuitem";

const { languages, locale, text } = useLanguage();

const items = computed<MenuItem[]>(() => [
	{
		label: "Living",
		icon: "pi pi-home",
		url: "/",
	},
	{
		label: text("menu_bar.signup"),
		icon: "pi pi-star",
		url: "/register",
	},
	{
		label: text("menu_bar.login"),
		icon: "pi pi-search",
		url: "/login",
	},
	{
		label: text("feed"),
		icon: "pi pi-globe",
		url: "/feed",
	},
]);
</script>

<template>
	<div>
		<Menubar :model="items">
			<template #item="{ item, hasSubmenu, root }">
				<NuxtLink
					v-ripple
					class="flex items-center"
					:to="item.url"
				>
					<span :class="item.icon" />
					<span class="ml-2">{{ item.label }}</span>
					<Badge
						v-if="item.badge"
						:class="{ 'ml-auto': !root, 'ml-2': root }"
						:value="item.badge"
					/>
					<span
						v-if="item.shortcut"
						class="ml-auto border border-surface rounded bg-emphasis text-muted-color text-xs p-1"
					>
						{{ item.shortcut }}
					</span>
					<i
						v-if="hasSubmenu"
						:class="['pi pi-angle-down', { 'pi-angle-down ml-2': root, 'pi-angle-right ml-auto': !root }]"
					/>
				</NuxtLink>
			</template>
			<template #end>
				<Dropdown
					model-value="locale"
					:options="languages"
					option-label="option"
					placeholder="Selecione um idioma"
					class="w-full md:w-14rem"
					@change="(e) => (locale = e.value.code)"
				/>
			</template>
		</Menubar>
		<slot />
	</div>
</template>
