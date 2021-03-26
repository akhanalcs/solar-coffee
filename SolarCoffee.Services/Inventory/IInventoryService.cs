using System;
using System.Collections.Generic;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Inventory
{
    //Contract to define the behavior of classes that might implement them
    public interface IInventoryService
    {
        List<ProductInventory> GetCurrentInventories();
        ProductInventory GetProductInventoryByProductId(int productId);
        ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment); //ServiceResponse that use ProductInventory as the T Data to send back
        List<ProductInventorySnapshot> GetSnapshotHistory();
    }
}