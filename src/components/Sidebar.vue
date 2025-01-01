<template>
  <aside class="sidebar">
    <!-- Sidebar Üst Kısım (Logo) -->
    <div class="sidebar-header">
      <img src="@/assets/images/logo.png" alt="Akyıldız Logo" class="logo" />
      <span class="sidebar-title">Akyıldız Lojistik</span>
    </div>

    <!-- Menü -->
    <nav>
      <ul class="menu">
        <li>
          <router-link to="/" class="menu-item" active-class="active">
            <svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
              <path stroke="none" d="M0 0h24H0z" fill="none" />
              <path d="M5 12l-2 0l9 -9l9 9l-2 0" />
              <path d="M5 12v7a2 2 0 0 0 2 2h10a2 2 0 0 0 2 -2v-7" />
              <path d="M9 21v-6a2 2 0 0 1 2 -2h2a2 2 0 0 1 2 2v6" />
            </svg>
            Home
          </router-link>
        </li>
        <li>
          <router-link to="/customer" class="menu-item" active-class="active">
            <svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
              <path stroke="none" d="M0 0h24V0z" fill="none" />
              <path d="M12 3l8 4.5v9l-8 4.5l-8 -4.5v-9z" />
              <path d="M12 12l8 -4.5" />
              <path d="M12 12l0 9" />
              <path d="M12 12l-8 -4.5" />
              <path d="M16 5.25l-8 4.5" />
            </svg>
            Müşteri
          </router-link>
        </li>
        <li>
          <router-link to="/palet" class="menu-item" active-class="active">
            <svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
              <path stroke="none" d="M0 0h24V0z" fill="none" />
              <path d="M12 3l8 4.5v9l-8 4.5l-8 -4.5v-9z" />
              <path d="M12 12l8 -4.5" />
              <path d="M12 12l0 9" />
              <path d="M12 12l-8 -4.5" />
              <path d="M16 5.25l-8 4.5" />
            </svg>
            Palet
          </router-link>
        </li>
        <li>
          <router-link to="/rackAddress" class="menu-item" active-class="active">
            <svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
              <path stroke="none" d="M0 0h24V0z" fill="none" />
              <path d="M12 3l8 4.5v9l-8 4.5l-8 -4.5v-9z" />
              <path d="M12 12l8 -4.5" />
              <path d="M12 12l0 9" />
              <path d="M12 12l-8 -4.5" />
              <path d="M16 5.25l-8 4.5" />
            </svg>
            Raf Adres
          </router-link>
        </li>
        <li>
          <router-link to="/about" class="menu-item" active-class="active">
            <svg xmlns="http://www.w3.org/2000/svg" class="icon" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
              <path stroke="none" d="M0 0h24V0z" fill="none" />
              <path d="M12 3l8 4.5v9l-8 4.5l-8 -4.5v-9z" />
              <path d="M12 12l8 -4.5" />
              <path d="M12 12l0 9" />
              <path d="M12 12l-8 -4.5" />
              <path d="M16 5.25l-8 4.5" />
            </svg>
            About
          </router-link>
        </li>
      </ul>
    </nav>
  </aside>
</template>

<script>
export default {
  name: "Sidebar",
};
</script>

<style scoped>
/* Sidebar Temel Yapı */
.sidebar {
  width: 250px;
  height: 100vh;
  background-color: #343a40;
  color: white;
  display: flex;
  flex-direction: column;
  position: fixed;
  top: 0;
  left: 0;
  overflow: hidden;
}

/* Sidebar Header */
.sidebar-header {
  padding: 20px;
  display: flex;
  align-items: center;
  background-color: #212529;
}

.logo {
  width: 40px;
  height: 40px;
  margin-right: 10px;
}

.sidebar-title {
  font-size: 1.2em;
  font-weight: bold;
  color: white;
}

/* Menü */
.menu {
  list-style: none;
  padding: 0;
  margin: 0;
}

.menu-item {
  display: flex;
  align-items: center;
  padding: 10px 20px;
  color: white;
  text-decoration: none;
  transition: background-color 0.3s ease;
}

.menu-item svg {
  margin-right: 10px;
}

.menu-item:hover,
.menu-item.active {
  background-color: #495057;
}
</style>
