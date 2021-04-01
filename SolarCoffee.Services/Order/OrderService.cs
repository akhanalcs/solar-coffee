using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.Inventory;
using SolarCoffee.Services.Product;

namespace SolarCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(SolarDbContext dbContext, ILogger<OrderService> logger, IProductService productService, IInventoryService inventoryService)
        {
            _db = dbContext;
            _logger = logger;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Creates an open sales order
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public ServiceResponse<bool> GenerateOpenOrder(SalesOrder salesOrder)
        {
            _logger.LogInformation("Generating new order");
            foreach (var item in salesOrder.SalesOrderItems)
            {
                var inventoryId = _inventoryService.GetProductInventoryByProductId(item.Product.Id).Id;
                _inventoryService.UpdateUnitsAvailable(inventoryId, -item.Quantity);
            }

            try
            {
                _db.SalesOrders.Add(salesOrder);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "Open order created",
                    Time = DateTime.UtcNow,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = ex.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }

        /// <summary>
        /// Gets all SalesOrders in the system
        /// </summary>
        /// <returns></returns>
        public List<SalesOrder> GetSalesOrders()
        {
            return _db.SalesOrders
                      .Include(so => so.Customer)
                        .ThenInclude(c => c.PrimaryAddress)
                      .Include(so => so.SalesOrderItems)
                        .ThenInclude(i => i.Product)
                      .ToList();
        }

        /// <summary>
        /// Marks an open sales order as paid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> MarkFulfilled(int id)
        {
            var now = DateTime.UtcNow;
            var order = _db.SalesOrders.Find(id);
            order.IsPaid = true;
            order.UpdatedOn = now;

            try
            {
                _db.SalesOrders.Update(order);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = $"Order {order.Id} closed: Invoice paid in full.",
                    Time = now,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = ex.StackTrace,
                    Time = now,
                    Data = false
                };
            }
        }
    }
}
