<template>
  <div>
    <h2>Add Palet</h2>
    <form @submit.prevent="submitForm">
      <div>
        <label for="paletNo">Palet Numarası:</label>
        <input v-model="paletNo" id="paletNo" required />
      </div>
      <div>
        <label for="address">Adres:</label>
        <input v-model="address" id="address" required />
      </div>
      <div>
        <label for="Situtation">Durum:</label>
        <select v-model="situtation" id="situtation" required>
          <option value="Depoda">Depoda</option>
          <option value="Kirada">Kirada</option>
          <option value="Hasarlı">Hasarlı</option>
        </select>
      </div>
      <button type="submit">Palet Ekle</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      paletNo: '',
      address: '',
      situtation: 'Depoda',
    }
  },
  methods: {
    async submitForm() {
      try {
        const response = await axios.post('http://localhost:6001/api/palet//add', {
          paletNo: this.paletNo,
          address: this.address,
          situtation: this.situtation,
          entyDate: new Date(),
        })
        alert(response.data.message)
      } catch (error) {
        console.log(error)
        alert('Palet Ekleme İşlemi Başarısız')
      }
    },
  },
}
</script>
