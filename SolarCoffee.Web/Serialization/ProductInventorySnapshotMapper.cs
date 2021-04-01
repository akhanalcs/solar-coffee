using System;
using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public class ProductInventorySnapshotMapper
    {
        public static ProductInventorySnapshotViewModel SerializeProductInventorySnapshot(ProductInventorySnapshot productInventorySnapshot)
        {
            return new ProductInventorySnapshotViewModel
            {
                Id = productInventorySnapshot.Id,
                Product = ProductMapper.SerializeProductModel(productInventorySnapshot.Product),
                QuantityOnHand = productInventorySnapshot.QuantityOnHand,
                SnapShotTime = productInventorySnapshot.SnapShotTime
            };
        }

        public static ProductInventorySnapshot SerializeProductInventorySnapshot(ProductInventorySnapshotViewModel productInventorySnapshotViewModel)
        {
            return new ProductInventorySnapshot
            {
                Id = productInventorySnapshotViewModel.Id,
                Product = ProductMapper.SerializeProductModel(productInventorySnapshotViewModel.Product),
                QuantityOnHand = productInventorySnapshotViewModel.QuantityOnHand,
                SnapShotTime = productInventorySnapshotViewModel.SnapShotTime
            };
        }
    }
}