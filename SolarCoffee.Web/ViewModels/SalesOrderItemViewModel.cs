using System;
namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for SalesOrderItems
    /// </summary>
    public class SalesOrderItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
