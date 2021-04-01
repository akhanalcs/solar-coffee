using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public class OrderMapper
    {
        /// <summary>
        /// Handles mapping Order data models to and from related View models
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceToOrder(InvoiceViewModel invoice)
        {
            var salesOrderItems = invoice.LineItems.Select(item => new SalesOrderItem
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductModel(item.Product)
            }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
                //Customer = _customerService.GetCustomerById(invoice.CustomerId) //Doing this step in the controller where this service is injected instead of doing that here.
            };
        }

        /// <summary>
        /// Maps a collection of SalesOrders (data) to OrderModels (view models)
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<OrderViewModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderViewModel
            {
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                Id = order.Id,
                IsPaid = order.IsPaid,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems (data) to SalesOrderItemModels (view models)
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static List<SalesOrderItemViewModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(soi => new SalesOrderItemViewModel
            {
                Id = soi.Id,
                Product = ProductMapper.SerializeProductModel(soi.Product),
                Quantity = soi.Quantity
            }).ToList();
        }
    }
}
