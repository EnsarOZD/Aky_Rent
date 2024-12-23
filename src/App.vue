<template>
  <div id="app">
    <!-- Dinamik olarak ilgili rota bileşenini yükler -->
     <Sidebar />
    <router-view />
  </div>
</template>

<script>
import Sidebar from './components/Sidebar.vue';
export default {
  name: 'App',
  components: {
    Sidebar,
  },
};
</script>

<style>
/* Gerekirse uygulama genel stillerini buraya ekleyebilirsiniz */
</style>
