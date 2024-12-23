<template>
    <div class="layout">
      <!-- Sidebar (Sabit Kısım) -->
      <Sidebar />
  
      <!-- Dinamik İçerik -->
      <div class="content">
        <router-view />
      </div>
    </div>
  </template>
  
  <script>
  import Sidebar from "@/components/Sidebar.vue";
  
  export default {
    name: "MainLayout",
    components: {
      Sidebar,
    },
  };
  </script>
  
  <style scoped>
  .layout {
    display: flex;
    min-height: 100vh; /* Tam ekran yüksekliği */
  }
  
  .content {
    flex: 1; /* İçeriğin genişliği esnek */
    padding: 20px;
    overflow: auto; /* İçeriğin taşmasını engeller */
  }
  </style>
  