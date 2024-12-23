import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'
import { fileURLToPath, URL } from 'node:url'

export default defineConfig({
  plugins: [vue(), vueDevTools()],
  server: {
    port: 6010, // Frontend Vue.js uygulamasının çalışacağı port
    proxy: {
      '/api': {
        target: 'http://localhost:6001', // Backend uygulamasının HTTP portu
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, ''), // "/api" yolunu kaldırarak Backend'e yönlendir
      },
    },
  },
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url)),
    },
  },
})
