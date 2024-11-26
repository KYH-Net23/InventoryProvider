using InventoryProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/deleteinventory")]
    [ApiController]
    public class DeleteInventoryController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _service.DeleteInventoryAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
