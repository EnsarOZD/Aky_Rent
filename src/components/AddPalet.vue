<template>
  <div>
    <h2>Add Palet</h2>
    <form @submit.prevent="submitForm">
      <div>
        <label for="paletNo">Palet Numarası:</label>
        <input v-model="paletNo" id="paletNo" required />
      </div>
      <div>
        <label for="addres">Adres:</label>
        <input v-model="addres" id="address" required />
      </div>
      <div>
        <label for="Situation">Durum:</label>
        <select v-model="situation" id="situation" required>
          <option value="Depoda">Depoda</option>
          <option value="Kirada">Kirada</option>
          <option value="Hasarlı">Hasarlı</option>
        </select>
      </div>
      <div>
  <label for="customerId">Müşteri:</label>
  <select v-model="customerId" id="customerId" required>
    <option v-for="customer in customers" :key="customer.id" :value="customer.id">
      {{ customer.name }}
    </option>
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
      addres: '',
      situation: 'Depoda',
      customerId: '',
      customers: [],
    }
  },
  mounted() {
    this.fetchCustomers()
  },
  methods: {
    async fetchCustomers() {
      try {
        const response = await axios.get('http://localhost:6001/api/customer/list')
        this.customers = response.data
      } catch (error) {
        console.log('Müşteri listesi alınırken hata oluştu:', error)
      }
    },
    async submitForm() {
      try {
        console.log({
        paletNo: this.paletNo,
        addres: this.addres,
        situation: this.situation,
        customerId: this.customerId,
        entyDate: new Date(),
      })
        const response = await axios.post('http://localhost:6001/api/palet/add', {
          paletNo: this.paletNo,
          addres: this.addres,
          situation: this.situation,
          entyDate: new Date(),
          customerId: this.customerId
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
