<template>
  <div>
    <h2>Palet List</h2>
    <table border="1">
      <thead>
        <tr>
          <th>ID</th>
          <th>Palet No</th>
          <th>Adres</th>
          <th>Durum</th>
          <th>Giriş Tarihi</th>
          <th>Çıkış Tarihi</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="palet in paletler" :key="palet.id">
          <td>{{ palet.id }}</td>
          <td>{{ palet.paletNo }}</td>
          <td>{{ palet.addres }}</td>
          <td>{{ palet.situation }}</td>
          <td>{{ palet.enteryDate }}</td>
          <td>{{ palet.exitDate || 'N/A' }}</td>
                    
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
