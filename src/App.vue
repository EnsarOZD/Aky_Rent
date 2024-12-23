<template>
  <div>
    <PaletEkle />
    <PaletListe />
  </div>
</template>

<script>
import PaletEkle from './components/AddPalet.vue'
import PaletListe from './components/PaletList.vue'

export default {
  components: {
    PaletEkle,
    PaletListe,
  },
}
</script>
