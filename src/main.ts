import './assets/main.css'
import './assets/css/tabler.min.css';

import './assets/js/tabler.min.js';

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

const app = createApp(App)


app.use(createPinia())
app.use(router)

app.mount('#app')
