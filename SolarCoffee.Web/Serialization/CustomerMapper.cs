using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public class CustomerMapper
    {
        /// <summary>
        /// Serializes a Customer data object to CustomerViewModel
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerViewModel SerializeCustomer(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = CustomerAddressMapper.SerializeCustomerAddress(customer.PrimaryAddress),
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn
            };
        }

        /// <summary>
        /// Serializes a CustomerViewModel to a Customer data model object
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerViewModel customerViewModel)
        {
            return new Customer
            {
                Id = customerViewModel.Id,
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                PrimaryAddress = CustomerAddressMapper.SerializeCustomerAddress(customerViewModel.PrimaryAddress),
                CreatedOn = customerViewModel.CreatedOn,
                UpdatedOn = customerViewModel.UpdatedOn
            };
        }

        /// <summary>
        /// Maps a collection of Customers (data) to CustomerViewModels (view model)
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public static IEnumerable<CustomerViewModel> MapCustomersToCustomerViewModels(IEnumerable<Customer> customers)
        {
            return customers.Select(customer => SerializeCustomer(customer));
        }
    }
}
