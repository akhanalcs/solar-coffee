using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<OrderService> _logger;

        public OrderService(SolarDbContext dbContext, ILogger<OrderService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }
        
        public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all SalesOrders in the system
        /// </summary>
        /// <returns></returns>
        public List<SalesOrder> GetSalesOrders()
        {
            return _db.SalesOrders
                      .Include(so => so.Customer)
                      .Include(so => so.SalesOrderItems)
                      .ToList();
        }

        public ServiceResponse<bool> MarkFulfilled(int id)
        {
            throw new NotImplementedException();
        }
    }
}
