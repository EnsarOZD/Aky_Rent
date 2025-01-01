import { createRouter, createWebHistory } from 'vue-router';
import PaletView from '@/views/PaletView.vue'; // Palet bileşeni
import AboutView from '@/views/AboutView.vue';
import CustomerView from '@/views/CustomerView.vue';
import RackAddressesViewVue from '@/views/RackAddressesView.vue';

const routes = [
  {
    path: '/palet',
    name: 'Palet',
    component: PaletView,
  },
  {
    path: '/about',
    name: 'About',
    component: AboutView,
  },
  {
    path: '/customer',
    name: 'Customer',
    component: CustomerView,
  },
  {
    path: '/rackAddress',
    name: 'RackAddress',
    component: RackAddressesViewVue,
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
