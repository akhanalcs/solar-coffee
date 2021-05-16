import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Inventory from "@/views/Inventory.vue";

const routes: Array<RouteRecordRaw> = [
  {
    name: "Home",
    path: "/",
    //component: Inventory, because we have this: "export default class Inventory extends Vue {}" in Inventory.vue and we have this here: import Inventory from "@/views/Inventory.vue";
    component: Inventory
  },
  {
    name: "Inventory",
    path: "/inventory",
    component: Inventory
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
