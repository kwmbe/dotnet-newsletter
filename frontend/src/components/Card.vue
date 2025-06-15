<script setup>
defineProps(["header"])
</script>

<template>
  <div class="card-bg flex-col shadow-xl/30 shadow-gray-500 p-10 rounded-xl relative z-0 overflow-hidden">
    <h2
      class="font-bold text-3xl relative z-1 pb-8"
    >
      {{header}}
    </h2>
    <div class="relative z-1">
      <slot />
    </div>
  </div>
</template>

<style scoped>
.card-bg {
  background: linear-gradient(135deg, lime, skyblue);
}
.card-bg:after  {
  content: "";
  position: absolute;
  top: -47.5vh;
  left: -100%;
  height: 100vh;
  width: 200%;
  background: #ffffff;
  transform: translateY(50%) rotate(5deg);
  z-index: 0;
}
</style>
