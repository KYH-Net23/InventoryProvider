using InventoryProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/getinventories")]
    [ApiController]
    public class GetInventoriesController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllInventoriesAsync();

            if (products != null && products.Count > 0)
            {
                return Ok(products);
            }
            return BadRequest();
        }
    }
}
