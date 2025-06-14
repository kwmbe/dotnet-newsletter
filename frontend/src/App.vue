<script setup>
import { ref } from "vue";
import Card from "./components/Card.vue"
import Input from "./components/Input.vue"

const email = ref("test");

const submitEmail = () => fetch("https://localhost:32779/Email?emailString=" + email.value, {
  method: "POST",
  mode: "no-cors",
}).then(res => console.log(res));

</script>

<template>
  <main>
    <Card header="Schrijf je in op onze wekelijkse nieuwsbrief">
      <Input
        placeholder="someone@starringjane.com"
        label="Jouw email"
        action="Inschrijven"
        :submit="submitEmail"
        v-model="email"
      />
    </Card>
  </main>
</template>

<style scoped>

@media (min-width: 1024px) {
  /* responsive */
}
</style>
