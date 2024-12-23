<template>
    <div class="palet-view">
        
      <h1>Palet Yönetimi</h1>
      <div class="add-palet">
        <AddPalet />
      </div>
      <div class="palet-list">
        <PaletList />
      </div>
    </div>
  </template>

<script>
import AddPalet from '@/components/AddPalet.vue';
import PaletList from '@/components/PaletList.vue';

export default {
    name: 'PaletView',
    components: {
        AddPalet,
        PaletList,
    },  
    };

</script>

<style scoped>
.palet-view {
  display: flex;
  
}
.content {
  flex: 1; /* Ana içeriğin genişliğini doldurması için */
  padding: 20px;
}


.add-palet {
  margin-bottom: 20px;
  border-bottom: 1px solid #ddd;
  padding-bottom: 20px;
}

.palet-list {
  margin-top: 20px;
}
</style>