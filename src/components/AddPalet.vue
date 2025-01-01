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
        <label for="rackAddressId" class="label">Raf Adresi</label>
        <select
          v-model="formData.rackAddressId"
          id="rackAddressId"
          class="input"
        >
          <option v-for="address in availableAddresses" :key="address.id" :value="address.id">
            Koridor: {{ address.corridorNumber }} - {{ address.corridorSide }},
            Sıra: {{ address.rowNumber }}, Kat: {{ address.level }}
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
        rackAddressId: '', // Seçilen raf adresi
      },
      availableAddresses: [], // Kullanılabilir adresler
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
    async handleSubmit() {
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
  },
};
</script>

<style scoped>
/* Stil buraya */
</style>
