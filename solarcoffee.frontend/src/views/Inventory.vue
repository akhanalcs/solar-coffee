<template>
    <div class="inventory-container">
        <h1 id="inventory-title">
            Inventory Dashboard
        </h1>
        <hr/>
    </div>
    <table id="inventory-table" class="table">
        <tr>
            <th>Item</th>
            <th>Quantity on hand</th>
            <th>Unit Price</th>
            <th>Taxable</th>
            <th>Delete</th>
        </tr>
        <tr v-for="item in inventory" v-bind:key="item.id" >
            <td>
                {{ item.product.name }}
            </td>
            <td>
                {{ item.quantityOnHand }}
            </td>
            <td>
                {{ $filters.price(item.price) }}
            </td>
            <td>
                <span v-if="item.product.isTaxable">
                    Yes
                </span>
                <span v-else>
                    No
                </span>
            </td>
            <td>
                <div>x</div>
            </td>
        </tr>
    </table>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { IProductInventory } from "@/types/Product";
import formatHelper from "@/helpers/formatHelper";

@Options({
    name: "Inventory",
    components: {}
})
export default class Inventory extends Vue{
    inventory:IProductInventory[] = [
       {
           id: 1,
           product: {
               id: 1,
               name: "some product",
               description: "Good stuff",
               price: 100,
               createdOn: new Date(),
               updatedOn: new Date(),
               isTaxable: true,
               isArchived: false
           },
           quantityOnHand: 100,
           idealQuantity: 100
       },
       {
           id: 2,
           product: {
               id: 2,
               name: "Another product",
               description: "Good stuff",
               price: 100,
               createdOn: new Date(),
               updatedOn: new Date(),
               isTaxable: false,
               isArchived: false
           },
           quantityOnHand: 40,
           idealQuantity: 20
       }
    ];
}
</script>

<style scoped>
</style>