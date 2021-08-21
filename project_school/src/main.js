import Vue from "vue";
import App from "./App.vue";
import VueResourse from "vue-resource";

Vue.config.productionTip = false;
Vue.use(VueResourse);

new Vue({
  render: (h) => h(App),
}).$mount("#app");
