<script lang="ts" setup>
import { onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useMovieStore } from '../stores/search'
import { storeToRefs } from 'pinia'
import popcorn from '../assets/popcorn.png'

const route = useRoute()
const router = useRouter()
const movieStore = useMovieStore()
const { movieDetail, loading, error } = storeToRefs(movieStore)
const { fetchMovieDetail } = movieStore

onMounted(() => {
  const movieId = route.params.id as string
  fetchMovieDetail(movieId)
})
</script>

<template>
  <v-container>
    <v-btn color="primary" @click="router.push('/')">🔙 Back to Search</v-btn>

    <v-progress-circular
      v-if="loading"
      indeterminate
      color="primary"
      class="d-block mx-auto mt-3"
    ></v-progress-circular>

    <v-alert v-if="error" type="error" class="mt-3">
      {{ error }}
    </v-alert>

    <v-card v-if="movieDetail" class="mt-4">
      <v-img
        :src="movieDetail.Poster !== 'N/A' ? movieDetail.Poster : popcorn"
        height="400px"
        cover
      ></v-img>
      <v-card-title>{{ movieDetail.Title }} ({{ movieDetail.Year }})</v-card-title>
      <v-card-subtitle>{{ movieDetail.Genre }}</v-card-subtitle>
      <v-card-text>
        <p><strong>Director:</strong> {{ movieDetail.Director }}</p>
        <p><strong>Actors:</strong> {{ movieDetail.Actors }}</p>
        <p><strong>Runtime:</strong> {{ movieDetail.Runtime }}</p>
        <p><strong>Plot:</strong> {{ movieDetail.Plot }}</p>
      </v-card-text>
    </v-card>
  </v-container>
</template>
