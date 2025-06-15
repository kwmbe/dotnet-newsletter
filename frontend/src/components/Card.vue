<script setup>
defineProps(["header"])
</script>

<template>
  <div class="flex-col">
    <h2>{{header}}</h2>
    <div>
      <slot />
    </div>
  </div>
</template>
