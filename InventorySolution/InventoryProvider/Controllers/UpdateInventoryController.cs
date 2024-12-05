using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/updateinventory")]
    [ApiController]
    public class UpdateInventoryController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] InventoryModel updateProduct)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _service.UpdateInventoryAsync(id, updateProduct);

                if (result == 1) return Ok(new { Message = "Inventory updated successfully.", Result = updateProduct });
                else if (result == 2) return BadRequest(new { Message = "Something went wrong " });
                else if (result == 0) return StatusCode(500, new { Message = "Error updating inventory OR no changes were made." });
                else return NotFound(new { Message = "Product was not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
