import { createRouter, createWebHistory } from 'vue-router';
import MainLayout from '@/layouts/MainLayout.vue'; // Ortak Layout bileşeni
import HomePage from '@/views/HomeView.vue'; // Ana sayfa bileşeni
import Palet from '@/views/PaletView.vue'; // Palet bileşeni

const routes = [
  {
    path: '/', // Ana rota
    component: MainLayout, // Ortak layout
    children: [
      {
        path: '', // Ana sayfa
        name: 'Home',
        component: HomePage,
      },
      {
        path: 'home', // Ana sayfa için alias
        name: 'HomeAlias',
        component: HomePage,
      },
      {
        path: 'palet', // Palet sayfası
        name: 'Palet',
        component: Palet,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
