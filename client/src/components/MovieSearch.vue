<script lang="ts" setup>
import { storeToRefs } from 'pinia'
import { useMovieStore } from '../stores/search'
import { computed, onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'

const movieStore = useMovieStore()
const { query, movies, loading, error, currentPage, totalResults } = storeToRefs(movieStore)
const { searchMovies } = movieStore
const hasSearched = ref(false)
const router = useRouter()
const totalPages = computed(() => Math.ceil(totalResults.value / 10))

onMounted(() => {
  error.value = ''
})

const searchHandler = async () => {
  hasSearched.value = true
  await searchMovies()
}
</script>

<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="12" md="8">
        <h2 class="text-center pa-5">🎬 Movie Search</h2>
        <v-text-field
          v-model="query"
          label="Enter movie title"
          clearable
          variant="outlined"
          @keyup.enter="searchMovies()"
        >
        </v-text-field>
        <v-btn color="primary" block @click="searchHandler()"> 🔍 Search </v-btn>

        <v-alert v-if="error" type="error" class="mt-3">
          {{ error }}
        </v-alert>
        <v-progress-circular
          v-if="loading"
          indeterminate
          color="primary"
          class="d-block mx-auto mt-3"
        ></v-progress-circular>

        <!-- Results -->
        <v-row v-if="movies.length" class="mt-4">
          <v-col v-for="movie in movies" :key="movie.imdbID" cols="12" sm="6" md="4">
            <v-card @click="router.push(`/movie/${movie.imdbID}`)" class="clickable-card">
              <v-img
                :src="movie.Poster !== 'N/A' ? movie.Poster : 'https://via.placeholder.com/150'"
                height="300px"
                cover
              ></v-img>
              <v-card-title>{{ movie.Title }}</v-card-title>
              <v-card-subtitle>{{ movie.Year }} - {{ movie.Type }}</v-card-subtitle>
            </v-card>
          </v-col>
        </v-row>

        <p v-else-if="hasSearched && !loading && !error" class="text-center mt-4">
          No results found.
        </p>

        <v-pagination
          v-if="totalPages > 1"
          v-model="currentPage"
          :length="totalPages"
          @update:model-value="searchMovies(currentPage)"
          class="mt-4"
        ></v-pagination>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped>
.clickable-card {
  cursor: pointer;
  transition: transform 0.2s;
}
.clickable-card:hover {
  transform: scale(1.05);
}
</style>
