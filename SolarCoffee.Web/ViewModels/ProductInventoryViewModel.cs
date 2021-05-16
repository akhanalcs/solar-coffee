using System;
namespace SolarCoffee.Web.ViewModels
{
    public class ProductInventoryViewModel
    {
        public int Id { get; set; }

        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
