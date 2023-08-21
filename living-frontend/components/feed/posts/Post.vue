<script setup  lang="ts">
import { Post } from '~/interfaces/posts/post'

const props = defineProps({
    post: Object as PropType<Post>,
})
console.log(props.post?.id)
</script>
<template></template>