import { createRouter, createWebHistory } from 'vue-router'
import AddPalet from '../components/AddPalet.vue'
import PaletList from '../components/PaletList.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: AddPalet, // Ana sayfa için Palet Ekle bileşeni
  },
  {
    path: '/palet-list',
    name: 'paletList',
    component: PaletList, // Palet Listesi sayfası
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
