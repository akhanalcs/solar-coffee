<template>
  <!-- Vue will render the matched components from router/index.ts here. -->
  <!-- Different components are being rendered where the router-view component is -->
  <div class="app-menu">
    <side-menu />
  </div>
  <div class="app-content">
    <router-view />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import SideMenu from "@/components/SideMenu.vue"; // @ is an alias to /src

@Options({
  name: 'App', //This name for App name in Vue devtools
  components: { SideMenu }
})
export default class App extends Vue{}
</script>

<style lang="scss">
@import "@/scss/global.scss";

#app1 {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  display: flex;

  .app-menu{
    //CSS POSTIONS
    //STATIC is the default position that all HTML elements have. 
    //Just follows html document flow. First comes first, second comes second and so on.

    //RELATIVE: almost works like static. But allows us to position it with params like top, left bottom and right.
    //If left 10px; then the element will move to the right by 10px and might even overflow from its parent element.
    //Lets us postion it relative to where it would have been if it was statically positioned. 
    //It gets removed from the document flow. 
    //Don't use it with top, left, right, bottom params.

    //ANY ELEMENT THAT IS RELATIVELY POSITIONED CAN HAVE ABSOLUTELY POSITIONED ELEMENTS INSIDE OF IT THAT'LL BE
    //RELATIVE TO THAT RELATIVELY POSITIONED ELEMENT.

    //ABSOLUTE postions element inside of some parent container that it can reference.
    //Absolute gets used with top, left right and bottom.
    //Absolute completely removes element from the document flow. Everything else renders as if the absolute element didn't even exist.
    
    //FIXED postioned elements are always positioned based on the entire HTML element and it has nothing to do with parents.
    //They stay in the same place when we scroll.
    //Fixed moves with the page as we scroll. Absolute elements stay relatively positioned inside of their parent.

    // STICKY position = Fixed + Relative. By default it's relative (very normal) but as soon as we scroll outside
    // of the page, it'll stay right where it is (fixed).
    position: fixed; //https://www.youtube.com/watch?v=jx5jmI0UlXU
  }

  .app-content{
    padding: 1.2rem;
    width: 90%;
    //Top, right, bottom and left. We want to keep $menu-width on the left so that the .app-menu doesn't overlap the .app-content
    margin: 1rem auto 1rem $menu-width;
    text-align: left;
  }
}

* {
  margin: 0;
}

a {
  text-decoration: none; // Don't want to underline the links
}

hr{
  border: 1px solid #eee;
  margin: 1rem 0;
}
</style>
