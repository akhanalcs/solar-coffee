using System;
using System.Collections.Generic;

namespace SolarCoffee.Services.Customer
{
    //Contract to define the behavior of classes that might implement them
    public interface ICustomerService
    {
        List<Data.Models.Customer> GetAllCustomers();
        Data.Models.Customer GetCustomerById(int id);
        ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer); //ServiceResponse that use Customer as the T Data to send back
        ServiceResponse<bool> DeleteCustomer(int id); //ServiceResponse that use bool as the T Data to send back
    }
}
