using System;
using System.Collections.Generic;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Order
{
    //Contract to define the behavior of classes that might implement them
    public interface IOrderService
    {
        List<SalesOrder> GetSalesOrders();
        ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder salesOrder); //ServiceResponse that use bool as the T Data to send back
        ServiceResponse<bool> MarkFulfilled(int id);
    }
}