import { createRouter, createWebHistory } from 'vue-router'
import MovieSearch from '../components/MovieSearch.vue'
import MovieDetail from '../components/MovieDetail.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MovieSearch,
    },
    { path: '/movie/:id', name: 'detail', component: MovieDetail, props: true },
  ],
})

export default router
