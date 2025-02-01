import { defineStore } from 'pinia'
import { ref } from 'vue'
import axios from 'axios'

interface Movie {
  Title: string
  Year: string
  Type: string
  Poster: string
  imdbID: string
}

interface MovieDetail extends Movie {
  Plot: string
  Genre: string
  Director: string
  Actors: string
  Runtime: string
}

export const useMovieStore = defineStore('movieStore', () => {
  const query = ref('')
  const movies = ref<Movie[]>([])
  const loading = ref(false)
  const error = ref('')
  const currentPage = ref(1)
  const totalResults = ref(0)
  const movieDetail = ref<MovieDetail | null>(null)

  const searchMovies = async (page = 1) => {
    if (!query.value.trim()) {
      error.value = 'Please enter a movie title.'
      return
    }

    loading.value = true
    error.value = ''
    currentPage.value = page

    try {
      const response = await axios.get(
        `http://localhost:5104/api/movies/search?title=${query.value}&page=${page}`,
      )

      movies.value = response.data.Search || []
      totalResults.value = parseInt(response.data.totalResults) || 0
    } catch (err) {
      error.value = 'Failed to fetch movies. Please try again.'
    } finally {
      loading.value = false
    }
  }

  const fetchMovieDetail = async (id: string) => {
    loading.value = true
    error.value = ''
    movieDetail.value = null

    try {
      const response = await axios.get(`http://localhost:5104/api/movies/detail?id=${id}`)
      movieDetail.value = response.data
      console.log(movieDetail.value)
    } catch (err) {
      error.value = 'Failed to fetch movie details. Please try again.'
    } finally {
      loading.value = false
    }
  }

  return {
    query,
    movies,
    loading,
    error,
    currentPage,
    totalResults,
    searchMovies,
    fetchMovieDetail,
    movieDetail,
  }
})
