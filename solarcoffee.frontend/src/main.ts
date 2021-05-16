import { createApp } from "vue";
import { Vue } from 'vue-class-component';
import { viewDepthKey } from "vue-router";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import formatHelper from "./helpers/formatHelper";

const app = createApp(App);
app.config.globalProperties.$filters = formatHelper
app.use(store)
   .use(router)
   .mount("#app1");

// createApp(App)
//   .use(store)
//   .use(router)
//   .mount("#app1");