<script lang="ts" setup>
const value = ref("");
</script>

<template>
  <NuxtLayout name="feed">
    <Tabs value="0">
      <TabList>
        <Tab value="0">
          Escrever
        </Tab>
        <Tab value="1">
          Pré-visualizar
        </Tab>
      </TabList>
      <TabPanels>
        <TabPanel value="0">
          <Editor v-model="value" editor-style="height: 320px" />
        </TabPanel>
        <TabPanel value="1">
          <Post :content="value" />
        </TabPanel>
      </TabPanels>
    </Tabs>
  </NuxtLayout>
</template>

<style>

</style>
