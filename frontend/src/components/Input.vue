<script setup>
defineProps(["label", "placeholder", "action", "submit"])
const model = defineModel()

const update = (e) => {
  model.value = $e.target.value;
}
</script>

<template>
  <label>{{label}}</label>
  <div>
    <input
      type="email"
      v-model="model"
      :placeholder="placeholder"
      @input="update"
    />
    <button @click="submit" >{{action}}</button>
  </div>
</template>
