<script lang="ts" setup>

</script>

<template>
	<NuxtLayout name="feed">
		<Post v-for="number in Array(5)" :key="number" class="mt-2" />
	</NuxtLayout>
</template>
