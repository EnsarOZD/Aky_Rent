<template>
  <div class="palet-view">
    <header class="header">
      <h1>Mşteri Yönetimi</h1>
      <p>Müşteri ekleme ve listeleme işlemlerinizi buradan yapabilirsiniz.</p>
    </header>

    <!-- Müşteri Ekleme Bölümü -->
    <div class="add-customer">
      <div class="card">
        <AddCustomer />
      </div>
    </div>

    <!-- Müşteri Listeleme Bölümü -->
    <div class="customer-list">
      <div class="card">
        <h2>Müşteri Listesi</h2>
        <CustomerList />
      </div>
    </div>
  </div>
</template>

<script>
import AddCustomer from '@/components/AddCustomer.vue';
import CustomerList from '@/components/CustomerList.vue';


export default {
  name: 'PaletView',
  components: {
    AddCustomer,
    CustomerList,
  },
};
</script>

<style scoped>
.customer-view {
  display: flex;
  flex-direction: column;
  gap: 20px; /* Kartlar arasında boşluk */
}

.customer-palet,
.palet-list {
  width: 100%; /* Tam genişlik */
  margin: 0 auto; /* Ortalanır */
}
</style>
