using System;
using System.Collections.Generic;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for open SalesOrders. This kinda maps to SalesOrder data model.
    /// </summary>
    public class InvoiceViewModel
    {
        public int Id { get; set; } //Corresponding to Order Id MyProperty
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemViewModel> LineItems { get; set; }
    }
}
