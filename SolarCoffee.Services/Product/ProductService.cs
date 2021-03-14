using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly SolarDbContext _db;

        public ProductService(SolarDbContext solarDbContext)
        {
            _db = solarDbContext;
        }

        /// <summary>
        /// Archives a Product by setting IsArchived to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Product> ArchiveProduct(int id)
        {
            try
            {
                var product = _db.Products.Find(id);
                if (product != null)
                {
                    product.IsArchived = true;
                }

                _db.Add(product);

                var productInventory = _db.ProductInventories.FirstOrDefault(pi => pi.Product.Id == id);
                if(productInventory != null)
                {
                    productInventory.IdealQuantity = 0;
                    productInventory.QuantityOnHand = 0;
                    productInventory.UpdatedOn = DateTime.UtcNow;
                }

                _db.Add(productInventory);

                var productInventorySnapShot = _db.ProductInventorySnapshots.FirstOrDefault(pis => pis.Product.Id == id);
                if (productInventorySnapShot != null)
                {
                    productInventorySnapShot.QuantityOnHand = 0;
                    productInventorySnapShot.SnapShotTime = DateTime.UtcNow;
                }

                _db.Add(productInventorySnapShot);

                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Archive successful",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = ex.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product)
        {
            try
            {
                _db.Products.Add(product); // EF will start tracking product as a Unit of Work

                var newInventory = new ProductInventory
                {
                    Product = product,
                    CreatedOn = DateTime.UtcNow,
                    IdealQuantity = 10,
                    QuantityOnHand = 1,
                    UpdatedOn = DateTime.UtcNow
                };

                _db.ProductInventories.Add(newInventory);

                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Saved New Product",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = ex.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Retrieves all products from the database
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        /// <summary>
        /// Retrieves a product by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }
    }
}
