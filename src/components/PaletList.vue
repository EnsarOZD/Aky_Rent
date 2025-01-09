<template>
  <div class="palet-list">
    <h2 class="text-xl font-bold mb-4">Palet List</h2>
    <table class="table-auto w-full border-collapse border border-gray-300">
      <thead>
        <tr class="bg-gray-200">          
          <th class="border px-4 py-2">Palet No</th>
          <th class="border px-4 py-2">Adres</th>
          <th class="border px-4 py-2">Durum</th>
          <th class="border px-4 py-2">Giriş Tarihi</th>
          <th class="border px-4 py-2">Çıkış Tarihi</th>
          <th class="border px-4 py-2">Müşteri</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="palet in paletler" :key="palet.id">          
          <td class="border px-4 py-2">{{ palet.paletNo }}</td>
          <td class="border px-4 py-2">{{ palet.address || 'N/A' }}</td>
          <td class="border px-4 py-2">{{ palet.situation }}</td>
          <td class="border px-4 py-2">{{ palet.enteryDate }}</td>
          <td class="border px-4 py-2">{{ palet.exitDate || 'N/A' }}</td>
          <td class="border px-4 py-2">{{ palet.customerName || 'N/A' }}</td>
                    
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      paletler: [],
    }
  },
  async created() {
    this.fetchPaletList();
    
  },
  methods: {
    async fetchPaletList() {
      try {
      const response = await axios.get('http://localhost:6001/api/palet/list')
      this.paletler=response.data
      
    } catch (error) {
      console.error(error)
      alert(
        'Palet listesi yüklenirken bir hata oluştu.Detay: ' + error.response?.data || error.message,
      )
    }
    },
  }
  // mounted() {
  //   this.created() // Bileşen yüklendiğinde API'yi çağır
  // },
}
</script>
<style scoped>
.table-auto {
  width: 100%;
  border-collapse: collapse;
}

th,
td {
  text-align: left;
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f4f4f4;
  font-weight: bold;
}

.text-green-600 {
  color: #16a34a; /* Yeşil renk */
}

.text-red-600 {
  color: #dc2626; /* Kırmızı renk */
}
</style>