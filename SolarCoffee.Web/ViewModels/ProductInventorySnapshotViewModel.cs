using System;
namespace SolarCoffee.Web.ViewModels
{
    public class ProductInventorySnapshotViewModel
    {
        public int Id { get; set; }

        public DateTime SnapShotTime { get; set; }
        public int QuantityOnHand { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
