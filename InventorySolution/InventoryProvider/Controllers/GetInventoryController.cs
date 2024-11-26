using InventoryProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryProvider.Controllers
{
    [Route("api/getinventory")]
    [ApiController]
    public class GetInventoryController(IInventoryService service) : ControllerBase
    {
        private readonly IInventoryService _service = service;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            try
            {
                var result = await _service.GetInventoryByIdAsync(id);

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
