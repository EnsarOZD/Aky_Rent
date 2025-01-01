<template>
  <div class="palet-view">
    <header class="header">
      <h1>Palet Yönetimi</h1>
      <p>Palet ekleme ve listeleme işlemlerinizi buradan yapabilirsiniz.</p>
    </header>

    <!-- Palet Ekleme Bölümü -->
    <div class="add-palet">
      <div class="card">
        <AddPalet />
      </div>
    </div>

    <!-- Palet Listeleme Bölümü -->
    <div class="palet-list">
      <div class="card">
        <h2>Palet Listesi</h2>
        <PaletList />
      </div>
    </div>
  </div>
</template>

<script>
import AddPalet from '@/components/AddPalet.vue';
import PaletList from '@/components/PaletList.vue';

export default {
  name: 'PaletView',
  components: {
    AddPalet,
    PaletList,
  },
};
</script>

<style scoped>
.palet-view {
  display: flex;
  flex-direction: column;
  gap: 20px; /* Kartlar arasında boşluk */
}

.add-palet,
.palet-list {
  width: 100%; /* Tam genişlik */
  margin: 0 auto; /* Ortalanır */
}
</style>
