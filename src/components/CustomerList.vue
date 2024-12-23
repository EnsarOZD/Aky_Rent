<template>
  <div>
    <h2>Customer List</h2>
    <table border="1">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Surname</th>
          <th>PhoneNumber</th>
          <th>Email</th>
          <th>CustomerAddress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in customers" :key="customer.id">
          <td>{{ customer.id }}</td>
          <td>{{ customer.name }}</td>
          <td>{{ customer.surname }}</td>
          <td>{{ customer.phoneNumber }}</td>
          <td>{{ customer.email }}</td>
          <td>{{ customer.customerAddress || 'N/A' }}</td>
                    
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
      customers: [],
    }
  },
  async created() {
    try {
      const response = await axios.get('http://localhost:6001/api/customer/list')
      this.customers=response.data
      
    } catch (error) {
      console.error(error)
      alert(
        'Müşteri listesi yüklenirken bir hata oluştu.Detay: ' + error.response?.data || error.message,
      )
    }
  },
  // mounted() {
  //   this.created() // Bileşen yüklendiğinde API'yi çağır
  // },
}
</script>
