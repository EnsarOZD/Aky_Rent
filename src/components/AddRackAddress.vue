<template>
  <div class="add-rack-address">
    <form @submit.prevent="handleSubmit" class="form">
      <div class="form-group">
        <label for="corridorNumber" class="label">Koridor Numarası</label>
        <input
          v-model="formData.corridorNumber"
          type="number"
          id="corridorNumber"
          class="input"
          placeholder="Koridor Numarası Girin"
        />
      </div>
      <div class="form-group">
        <label for="corridorSide" class="label">Koridor Yönü</label>
        <select v-model="formData.corridorSide" id="corridorSide" class="input">
          <option value="K">Kuzey</option>
          <option value="G">Güney</option>
        </select>
      </div>
      <div class="form-group">
        <label for="rowNumber" class="label">Sıra Numarası</label>
        <input
          v-model="formData.rowNumber"
          type="number"
          id="rowNumber"
          class="input"
          placeholder="Sıra Numarası Girin"
        />
      </div>
      <div class="form-group">
        <label for="level" class="label">Kat</label>
        <input
          v-model="formData.level"
          type="number"
          id="level"
          class="input"
          placeholder="Kat Numarası Girin"
        />
      </div>
      <button type="submit" class="button">Kaydet</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  props: {
    address: {
      type: Object,
      default: () => ({}),
    },
  },
  data() {
    return {
      formData: { ...this.address },
    };
  },
  methods: {
    async handleSubmit() {
      try {
        if (this.formData.id) {
          // Mevcut adresi güncelle
          await axios.put(
            `http://localhost:6010/api/rackAddress/${this.formData.id}`,
            this.formData
          );
        } else {
          // Yeni adres ekle
          await axios.post(
            'http://localhost:6010/api/rackAddress/add',
            this.formData
          );
        }
        this.$emit('refresh'); // Listeyi yenile
        this.resetForm(); // Formu temizle
      } catch (error) {
        console.error('Adres kaydedilirken bir hata oluştu:', error);
      }
    },
    resetForm() {
      this.formData = {
        corridorNumber: '',
        corridorSide: '',
        rowNumber: '',
        level: '',
      };
    },
  },
};
</script>

<style scoped>
.add-rack-address {
  padding: 1rem;
  background-color: #f9f9f9;
  border: 1px solid #ddd;
  border-radius: 5px;
}

.form-group {
  margin-bottom: 1rem;
}

.label {
  display: block;
  font-weight: bold;
  margin-bottom: 0.5rem;
}

.input {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.button {
  background-color: #007bff;
  color: #fff;
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.button:hover {
  background-color: #0056b3;
}
</style>
