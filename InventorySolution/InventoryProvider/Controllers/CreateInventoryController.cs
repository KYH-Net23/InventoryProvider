using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/createinventory")]
    [ApiController]
    public class CreateInventoryController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;
        [HttpPost]
        public async Task<ActionResult> CreateProduct(InventoryModel model)
        {
            try
            {
                var result = await _service.CreateInventoryAsync(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
