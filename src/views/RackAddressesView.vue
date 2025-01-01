<template>
    <div>
      <header>
        <h1>Raf Adresleri Yönetimi</h1>
      </header>
      <RackAddressList
        :addresses="addresses"
        @edit="handleEdit"
        @delete="handleDelete"
      />
    </div>
  </template>
  
  <script>
  import RackAddressList from '@/components/RackAddressList.vue';
  import axios from 'axios';
  
  export default {
    components: { RackAddressList },
    data() {
      return {
        addresses: [], // Backend'den gelecek adresler
      };
    },
    methods: {
      handleEdit(address) {
        console.log('Düzenlenecek adres:', address);
        // Düzenleme mantığını buraya ekleyebilirsiniz
      },
      handleDelete(id) {
        console.log('Silinecek adres ID:', id);
        // Silme mantığını buraya ekleyebilirsiniz
      },
    },
    mounted() {
      // Adresleri backend'den yükleme
      this.fetchAddresses();
    },
    methods: {
      async fetchAddresses() {
        try {
          const response = await axios.get('http://localhost:6001/api/rackAddress/list');
          this.addresses = response.data;
        } catch (error) {
          console.error('Adresler yüklenirken hata oluştu:', error);
        }
      },
    },
  };
  </script>
  