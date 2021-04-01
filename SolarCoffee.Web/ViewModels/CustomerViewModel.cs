using System;
namespace SolarCoffee.Web.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public CustomerAddressViewModel PrimaryAddress { get; set; }
    }
}
