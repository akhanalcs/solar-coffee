using System;
using System.Collections.Generic;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Product
{
    //Contract to define the behavior of classes that might implement them
    public interface IProductService
    {
        List<Data.Models.Product> GetAllProducts();
        Data.Models.Product GetProductById(int id);
        ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product); //ServiceResponse that use Product as the T Data to send back
        ServiceResponse<Data.Models.Product> ArchiveProduct(int id);
    }
}
