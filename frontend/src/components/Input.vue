<script setup>
defineProps(["label", "placeholder", "action", "submit"])
const model = defineModel()

const update = (e) => {
  model.value = e.target.value;
}
</script>

<template>
  <label class="font-semibold">{{label}}</label>
  <div class="flex">
    <input
      class="border-solid border-1 rounded-l-md p-2 px-4 border-gray-500 w-full"
      type="email"
      v-model="model"
      :placeholder="placeholder"
      @input="update"
    />
    <button
      class="border-solid border-1 rounded-r-md p-2 px-4 border-gray-500 font-bold"
      @click="submit"
    >
      {{action}}
    </button>
  </div>
</template>
