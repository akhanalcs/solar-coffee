using System;
using SolarCoffee.Web.ViewModels;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Web.Serialization
{
    public class ProductInventoryMapper
    {
        public static ProductInventoryViewModel SerializeProductInventory(ProductInventory productInventory)
        {
            return new ProductInventoryViewModel
            {
                Id = productInventory.Id,
                Product = ProductMapper.SerializeProductModel(productInventory.Product),
                IdealQuantity = productInventory.IdealQuantity,
                QuantityOnHand = productInventory.QuantityOnHand
            };
        }

        public static ProductInventory SerializeProductInventory(ProductInventoryViewModel productInventoryViewModel)
        {
            return new ProductInventory
            {
                Id = productInventoryViewModel.Id,
                Product = ProductMapper.SerializeProductModel(productInventoryViewModel.Product),
                IdealQuantity = productInventoryViewModel.IdealQuantity,
                QuantityOnHand = productInventoryViewModel.QuantityOnHand
            };
        }
    }
}
