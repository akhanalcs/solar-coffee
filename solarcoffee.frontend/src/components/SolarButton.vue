<template>
    <div class="btn-link">
        <button 
            v-on:click="visitRoute" 
            v-bind:class="['solar-button', { 'full-width': isFullWidth }]"
        >
            <slot></slot>
        </button>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";

 @Options({
    name: "SolarButton",
    components: { },
    props:{
        link:{
            type: String, // String vs string https://stackoverflow.com/a/57112602/8644294
            required: false
        },
        isFullWidth:{
            type: Boolean,
            required: false,
            default: false
        }
    }
 })
 export default class SolarButton extends Vue{
     link?:string; //In classes use string. In props declaration use String
     isFullWidth!:boolean;

     visitRoute(){
         this.$router.push(this.link?? "");
     }
 }
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
    .full-width{
        display: block;
        width: 100%;
    }
    
    .solar-button{
        background: lighten($color: $solar-blue, $amount: 20%);//lighten by 20%
        color: white;//text color
        padding: 0.8rem;
        transition: background-color 0.5s;
        margin: 0.3rem 0.2rem;
        display: inline-block;
        cursor: pointer;
        font-size: 1rem;
        min-width: 100px;
        border: none;
        border-bottom: 2px solid darken($color: $solar-blue, $amount: 20%);//2px thick border at the bottom
        border-radius: 3px;

        &:hover{
            background: darken($color: $solar-blue, $amount: 20%);
            transition: background-color 0.5s;
        }

        &:disabled{
            background: lighten($color: $solar-blue, $amount: 15%);
            border-bottom: 2px solid lighten($color: $solar-blue, $amount: 20%);
        }

        &:active{
            background: $solar-yellow;
            border-bottom: 2px solid lighten($color: $solar-yellow, $amount: 20%);
        }
    }
</style>