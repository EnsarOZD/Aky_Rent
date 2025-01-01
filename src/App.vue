<template>
  <div id="app" class="app-layout">
    <!-- Sidebar sabit genişlikte -->
    <Sidebar />
    
    <!-- İçerik alanı -->
    <main class="app-content">
      <router-view />
    </main>
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

<style scoped>
/* Genel düzen */
.app-layout {
  display: flex; /* Yan yana düzen */
  height: 100vh; /* Tam ekran yüksekliği */
  width: 100%; /* Tam genişlik */
  overflow: hidden; /* Taşma sorunlarını önlemek için */
}

/* Sidebar */
.app-layout > Sidebar {
  width: 250px; /* Sidebar genişliği sabit */
  background-color: #343a40; /* Sidebar için koyu arka plan */
  color: white;
  overflow-y: auto; /* Dikey kaydırma desteği */
  height: 100%; /* Tam yükseklik */
}

/* İçerik alanı */
.app-content {
  flex-grow: 1; /* Kalan alanı kapla */
  width: calc(100% - 250px); /* Sidebar genişliğini çıkar */
  padding: 20px; /* İçerik çevresinde boşluk */
  background-color: #f8f9fa; /* Hafif gri arka plan */
  overflow-y: auto; /* Dikey kaydırma desteği */
  box-sizing: border-box; /* Padding dahil genişlik hesaplaması */
}
</style>
