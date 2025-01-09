<template>
  <div class="add-palet">
    <form @submit.prevent="handleSubmit" class="form">
      <div class="form-group">
        <label for="paletNo" class="label">Palet Numarası</label>
        <input
          v-model="formData.paletNo"
          type="text"
          id="paletNo"
          class="input"
          placeholder="Palet Numarası Girin"
        />
      </div>
      <div class="form-group">
        <label for="Situation" class="label">Palet Durumu</label>
        <input
          v-model="formData.Situation"
          type="text"
          id="Situation"
          class="input"
          placeholder="Palet Durumu Girin"
        />
      </div>
      <div class="form-group">
        <label for="AddressId" class="label">Raf Adresi</label>
        <select
          v-model="formData.AddressId"
          id="AddressId"
          class="input"
        >
          <option v-for="address in availableAddresses" :key="address.id" :value="address.id">
            Koridor: {{ address.corridorNumber }} - {{ address.corridorSide }},
            Sıra: {{ address.rowNumber }}, Kat: {{ address.level }}
          </option>
        </select>
      </div>
      <div class="form-group">
        <label for="customerId" class="label">Müşteri</label>
        <select
          v-model="formData.customerId"
          id="customerId"
          class="input"
        >
          <option v-for="customer in customers" :key="customer.id" :value="customer.id">
            {{ customer.name }} - {{ customer.contactInfo }}
          </option>
        </select>
      </div>
      <button type="submit" class="button">Kaydet</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      formData: {
        paletNo: '',
        AddressId: '', // Seçilen raf adresi
        Situation: 'Belirtilmedi',
        customerId: '', // Seçilen müşteri
      },
      availableAddresses: [], // Kullanılabilir raf adresleri
      customers: [], // Tüm müşteriler
    };
  },
  methods: {
    async fetchAvailableAddresses() {
      try {
        const response = await axios.get('http://localhost:6001/api/rackAddress/list');
        this.availableAddresses = response.data.filter(
          (address) => !address.palletId // Sadece boş adresler
        );
      } catch (error) {
        console.error('Raf adresleri alınırken hata oluştu:', error);
      }
    },
    async fetchCustomers() {
      try {
        const response = await axios.get('http://localhost:6001/api/customer/list');
        this.customers = response.data; // Tüm müşterileri alıyoruz
      } catch (error) {
        console.error('Müşteriler alınırken hata oluştu:', error);
      }
    },
    async handleSubmit() {
      console.log("Gönderilen Veri:", this.formData); 
      try {
        
        await axios.post('http://localhost:6001/api/palet/add', this.formData);
        alert('Palet başarıyla eklendi!');
        this.$emit('refresh'); // Listeyi yenile
      } catch (error) {
        console.error('Palet kaydedilirken hata oluştu:', error);
      }
    },
  },
  mounted() {
    this.fetchAvailableAddresses();
    this.fetchCustomers();
  },
};
</script>

<style scoped>
/* Stil buraya */
</style>
