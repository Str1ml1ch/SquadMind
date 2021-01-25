import Vue from 'vue'
import App from './App.vue'
import bootstrap from './bootstrap'
import router from './route'

Vue.config.productionTip = false

new Vue({
  bootstrap,
  router,
  render: h => h(App),
}).$mount('#app')
