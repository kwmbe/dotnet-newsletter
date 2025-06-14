<script setup>
defineProps(["header"])
</script>

<template>
  <div class="container">
    <h2>{{header}}</h2>
    <div>
      <slot />
    </div>
  </div>
</template>

<style scoped>

.container {
  display: flex;
  flex-direction: column;
}

</style>
