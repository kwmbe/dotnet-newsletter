<script setup>
import { ref, watch } from "vue"
import Card from "./components/Card.vue"
import Input from "./components/Input.vue"

const email = ref("")
var error = ""

const submitEmail = () => {
  if (!error && email.value) {
    fetch("https://localhost:32779/Email?emailString=" + email.value.trim(), {
      method: "POST",
    })
    .then(res => res.text())
    .then(res => res ? alert(res) : alert("Successvol ingescreven"))
  } else alert("Fouten in het email-adres")
}

watch(email, (newEmail) => {
  // regular expression from https://emailregex.com/
  const reg = /(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/
  let matched = reg.exec(newEmail)

  if (matched?.length && matched[0] == email.value)
    error = ""
  else
    error = "Geen correct email-adres"
})
</script>

<template>
  <main class="flex justify-center items-center h-screen">
    <Card header="Schrijf je in op onze wekelijkse nieuwsbrief">
      <Input
        placeholder="someone@starringjane.com"
        label="Jouw email"
        action="Inschrijven"
        :submit="submitEmail"
        v-model="email"
      />
      <p class="text-red-500">{{error}}</p>
    </Card>
  </main>
</template>

<style>
@import "tailwindcss"
</style>
