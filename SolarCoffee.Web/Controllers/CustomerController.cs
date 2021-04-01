using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerViewModel customerViewModel)
        {
            _logger.LogInformation("Creating a new customer");
            customerViewModel.CreatedOn = DateTime.UtcNow;
            customerViewModel.UpdatedOn = DateTime.UtcNow;
            var customerData = CustomerMapper.SerializeCustomer(customerViewModel);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpGet("/api/customers")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting customers.");
            var customers = _customerService.GetAllCustomers();
            var customerModels = CustomerMapper
                                    .MapCustomersToCustomerViewModels(customers)
                                    .OrderByDescending(cust => cust.CreatedOn)
                                    .ToList();
            return Ok(customerModels);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting a customer");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}
