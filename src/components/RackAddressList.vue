<template>
  <div class="rack-address-list">
    <h2 class="text-xl font-bold mb-4">Koridor Adres Listesi</h2>
    <table class="table-auto w-full border-collapse border border-gray-300">
      <thead>
        <tr class="bg-gray-200">
          <th class="border px-4 py-2">ID</th>
          <th class="border px-4 py-2">Koridor</th>
          <th class="border px-4 py-2">Yön</th>
          <th class="border px-4 py-2">Sıra</th>
          <th class="border px-4 py-2">Kat</th>
          <th class="border px-4 py-2">Durum</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="address in addresses" :key="address.id">
          <td class="border px-4 py-2">{{ address.id }}</td>
          <td class="border px-4 py-2">{{ address.corridorNumber }}</td>
          <td class="border px-4 py-2">{{ address.corridorSide }}</td>
          <td class="border px-4 py-2">{{ address.rowNumber }}</td>
          <td class="border px-4 py-2">{{ address.level }}</td>
          <td class="border px-4 py-2">
            <span
              v-if="address.isOccupied"
              class="text-green-600 font-semibold"
            >
              Dolu
            </span>
            <span
              v-else
              class="text-red-600 font-semibold"
            >
              Boş
            </span>
          </td>
        </tr>
      </tbody>
    </table>
    <p v-if="!addresses.length" class="text-gray-500 text-center mt-4">
      Listelenecek adres bulunamadı.
    </p>
  </div>
</template>

<script>
export default {
  props: {
    addresses: {
      type: Array,
      default: () => [],
    },
  },
};
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
