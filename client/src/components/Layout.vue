<script setup lang="ts">
import { useRouter } from 'vue-router'
const router = useRouter()
</script>

<template>
  <v-app>
    <!-- Navbar -->
    <v-app-bar color="primary" dark>
      <v-btn text @click="router.push('/')">
        <v-toolbar-title>🎬 Movie Search</v-toolbar-title>
      </v-btn>
    </v-app-bar>

    <v-main class="full-width">
      <v-container fluid class="pa-0 ma-0">
        <slot />
      </v-container>
    </v-main>

    <!-- Footer -->
    <v-footer color="primary" app>
      <v-row justify="center">
        <v-col class="text-center white--text">© 2025 Movie Finder</v-col>
      </v-row>
    </v-footer>
  </v-app>
</template>

<style scoped>
.full-width {
  width: 100vw;
}
</style>
