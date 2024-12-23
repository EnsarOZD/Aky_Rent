<template>
  <div>
    <h2>Add Customer</h2>
    <form @submit.prevent="submitForm">
      <div>
        <label for="name">Müşteri İsmi:</label>
        <input v-model="name" id="name" required />
      </div>
      <div>
        <label for="surname">Müşteri Soyisim:</label>
        <input v-model="surname" id="surname" required />
      </div>
      <div>
        <div>
        <label for="phoneNumber">Müşteri Tel:</label>
        <input v-model="phoneNumber" id="phoneNumber" required />
        </div>
        <div>
        <label for="Email">Müşteri Email:</label>
        <input v-model="email" id="email" required />
        </div>
        <div>
        <label for="customerAddress">Müşteri Adres:</label>
        <input v-model="customerAddress" id="customerAddress" required />
        </div>
      </div>      
      <button type="submit">Müşteri Ekle</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      name: '',
      surname: '',
      phoneNumber: '',
      email: '',
      customerAddress: '',
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
        name: this.name,
        surname: this.surname,
        phoneNumber: this.phoneNumber,
        email: this.email,
        customerAddress: this.customerAddress,
      })
        const response = await axios.post('http://localhost:6001/api/customer/add', {
          name: this.name,
          surname: this.surname,
          phoneNumber: this.phoneNumber,
          email: this.email,
          customerAddress: this.customerAddress,
        })
        alert(response.data.message)
      } catch (error) {
        console.log(error)
        alert('Müşteri ekleme İşlemi Başarısız')
      }
    },
  },
}
</script>
