<template>
    <div class="side-menu-container">
        <!-- The path "/" is in router/index.ts -->
        <!-- Vue will render the matched component from router/index.ts inside <router-view /> tag which is in App.vue-->
        <router-link to="/">
            <img id="img-logo" alt="Solar Coffee Logo" src="../assets/images/solar_coffee_logo.png">
        </router-link>

        <h1>Management Portal</h1>
        <!--Inventory will go in to the Slot-->
        <!--link will go in to the prop-->
        <solar-button 
            id="menuInventory"
            v-bind:link="'/inventory'"
            v-bind:is-full-width=true
        >
            Inventory
        </solar-button>

        <solar-button
            id="menuCustomers"
            v-bind:link="'/customers'"
            v-bind:is-full-width=true
        >
            Manage Customers
        </solar-button>

        <solar-button
            id="menuInvoice"
            v-bind:link="'/invoice/new'"
            v-bind:is-full-width=true
        >
            New Invoice
        </solar-button>

        <solar-button
            id="menuOrders"
            v-bind:link="'/orders'"
            v-bind:is-full-width=true
        >
            Orders
        </solar-button>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import SolarButton from "@/components/SolarButton.vue";

//@Options decorator. It was previously @Component. It is optional now.
//https://class-component.vuejs.org/guide/class-component.html#other-options
@Options({
    name: 'SideMenu', //This name for SideMenu name in Vue devtools
    components: { SolarButton }, //Will contain the components that SideMenu needs to use
    // props: {
    //    msg: String
    // }
})
export default class SideMenu extends Vue {
  msg!: string; //! is definite assignment assertion saying that msg will have some value at runtime

  // Class properties will be component data
  myNumber: number = 0;

  // Declared as component method
  incrementNumber(){
    this.myNumber += 1;
  }

  // Lifecycle hooks
  created(){
    console.log('Created')
  }

  mounted(){
    console.log('Mounted')
  }
  
  // Called when we change routes; meaning when <router-view /> re-renders 
  destroyed(){
    console.log('Destroyed')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    @import "@/scss/global.scss"; // @ is an alias to /src
    .side-menu-container{
        background-color: #fcfcfc;
        height: 100vh; //100% view height
        width: $menu-width; //a variable coming in from global.scss
        display: flex; //flex means to put elements in a continuous row (left to right) instead of one below another. https://www.youtube.com/watch?v=Egqy7oOoNMw
        flex-direction: column; //Now elements are stacked on top of each other.
        padding: 0.8rem; //Padding of 0.8 rem Relative to html body is applied on all 4 sides.
        box-shadow: 0 1px 1px rgba(0,0,0,0.1), 0 1px 1px rgba(0,0,0,0.24); //Shadow on the side menu class' box model. Horizontal displacement Vertical displacement blur radius color (0,0,0 with an alpha factor of 12% instead of 100% dark) https://www.youtube.com/watch?v=dPRt7Dh9YD4
        box-sizing: border-box; // If a box is not using this property or using the content box value then only the content will have the original setting. Margin, padding becomes extra. But with this if you ask 100px, the box will be 100px. No more, no less. Pretty neat stuff!
    }

    #img-logo{
        width: 100%;
    }

    h1{
        font-size: 1.2rem;
        margin: 1rem 0; // 1rem top and bottom. 0 right and left. They go top, right, bottom and left.
    }
</style>