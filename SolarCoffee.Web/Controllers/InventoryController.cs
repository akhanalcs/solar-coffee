using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Inventory;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting all inventory.");
            var inventory = _inventoryService.GetCurrentInventories()
                                             .Select(pi => ProductInventoryMapper.SerializeProductInventory(pi))
                                             .OrderBy(pi => pi.Product.Name)
                                             .ToList();
            return Ok(inventory);
        }

        [HttpPatch("/api/inventory/update")]
        public ActionResult UpdateInventory([FromBody] ShipmentModel shipmentModel)
        {
            _logger.LogInformation($"Updating inventory for {shipmentModel.ProductId}.");
            var inventory = _inventoryService.UpdateUnitsAvailable(shipmentModel.ProductId, shipmentModel.Adjustment);
            return Ok(inventory);
        }
    }
}
