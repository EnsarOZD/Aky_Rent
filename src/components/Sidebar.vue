<template>
    <aside class="navbar navbar-vertical navbar-expand-lg" data-bs-theme="dark">
      <div class="container-fluid">
        <!-- Sidebar Header -->
        <h1 class="navbar-brand navbar-brand-autodark">
          <router-link to="/">
            <img
              src="@/assets/images/logo.png"
              width="110"
              height="32"
              alt="Akyıldız Logo"
              class="navbar-brand-image"
            />
            <span class="navbar-brand-text"> Akyıldız Lojistik</span>
          </router-link>
        </h1>
  
        <!-- Sidebar Menu -->
        <div class="collapse navbar-collapse" id="sidebar-menu">
          <ul class="navbar-nav pt-lg-3">
            <li class="nav-item">
              <router-link to="/" class="nav-link">
                <span class="nav-link-icon d-md-none d-lg-inline-block">
                  <!-- Home Icon -->
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    class="icon"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    stroke-width="2"
                    stroke="currentColor"
                    fill="none"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                  >
                    <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                    <path d="M5 12l-2 0l9 -9l9 9l-2 0" />
                    <path d="M5 12v7a2 2 0 0 0 2 2h10a2 2 0 0 0 2 -2v-7" />
                    <path d="M9 21v-6a2 2 0 0 1 2 -2h2a2 2 0 0 1 2 2v6" />
                  </svg>
                </span>
                <span class="nav-link-title">Home</span>
              </router-link>
            </li>
            <li class="nav-item">
              <router-link to="/palet" class="nav-link">
                <span class="nav-link-icon d-md-none d-lg-inline-block">
                  <!-- Palet Icon -->
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    class="icon"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    stroke-width="2"
                    stroke="currentColor"
                    fill="none"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                  >
                    <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                    <path d="M5 12l-2 0l9 -9l9 9l-2 0" />
                    <path d="M5 12v7a2 2 0 0 0 2 2h10a2 2 0 0 0 2 -2v-7" />
                    <path d="M9 21v-6a2 2 0 0 1 2 -2h2a2 2 0 0 1 2 2v6" />
                  </svg>
                </span>
                <span class="nav-link-title">Palet</span>
              </router-link>
            </li>
          </ul>
        </div>
      </div>
    </aside>
  </template>
  