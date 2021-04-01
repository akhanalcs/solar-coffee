using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.Services.Order;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        //FromBody means that the coming in request body needs to have the shape of InvoiceViewModel (This kinda maps to SalesOrder data model.)
        [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody]InvoiceViewModel invoiceViewModel)
        {
            _logger.LogInformation("Generating invoice");
            var order = OrderMapper.SerializeInvoiceToOrder(invoiceViewModel);
            order.Customer = _customerService.GetCustomerById(invoiceViewModel.CustomerId); //Doing this step here in the controller where the service is injected instead of doing it in OrderMapper.SerializeInvoiceToOrder.
            var serviceResponse = _orderService.GenerateOpenOrder(order);
            return Ok(serviceResponse);
        }

        [HttpGet("/api/orders")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetSalesOrders();
            var orderModels = OrderMapper.SerializeOrdersToViewModels(orders);
            return Ok(orderModels);
        }

        //patch because we're updating an existing record
        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult MarkOrderComplete(int id)
        {
            _logger.LogInformation($"Marking order {id} complete.");
            _orderService.MarkFulfilled(id);
            return Ok();
        }
    }
}
