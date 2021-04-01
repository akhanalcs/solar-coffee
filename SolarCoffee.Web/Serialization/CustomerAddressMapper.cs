using System;
using SolarCoffee.Web.ViewModels;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Web.Serialization
{
    public class CustomerAddressMapper
    {
        /// <summary>
        /// Maps a CustomerAddress data model to a CustomerAddressViewModel object
        /// </summary>
        /// <param name="customerAddress"></param>
        /// <returns></returns>
        public static CustomerAddressViewModel SerializeCustomerAddress(CustomerAddress customerAddress)
        {
            return new CustomerAddressViewModel
            {
                Id = customerAddress.Id,
                AddressLine1 = customerAddress.AddressLine1,
                AddressLine2 = customerAddress.AddressLine2,
                City = customerAddress.City,
                Country = customerAddress.Country,
                State = customerAddress.State,
                PostalCode = customerAddress.PostalCode,
                CreatedOn = customerAddress.CreatedOn,
                UpdatedOn = customerAddress.UpdatedOn
            };
        }

        /// <summary>
        /// Maps a CustomerAddressViewModel object to a CustomerAddress data model
        /// </summary>
        /// <param name="customerAddressViewModel"></param>
        /// <returns></returns>
        public static CustomerAddress SerializeCustomerAddress(CustomerAddressViewModel customerAddressViewModel)
        {
            return new CustomerAddress
            {
                Id = customerAddressViewModel.Id,
                AddressLine1 = customerAddressViewModel.AddressLine1,
                AddressLine2 = customerAddressViewModel.AddressLine2,
                City = customerAddressViewModel.City,
                Country = customerAddressViewModel.Country,
                State = customerAddressViewModel.State,
                PostalCode = customerAddressViewModel.PostalCode,
                CreatedOn = customerAddressViewModel.CreatedOn,
                UpdatedOn = customerAddressViewModel.UpdatedOn
            };
        }
    }
}
