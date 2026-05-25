using Microsoft.AspNetCore.Mvc;
using OrderProcessingServices.Services;
using OrderProcessingServices.DTOs;

namespace OrderProcessingServices.Controllers
{
    [ApiController]
    [Route("internal/orders")]
    public class InternalOrdersController : ControllerBase
    {
        private readonly OrderProcessingService _service;

        public InternalOrdersController(OrderProcessingService service)
        {
            _service = service;
        }

        [HttpPost("process")]
        public async Task<IActionResult> Process(CreateOrderRequestDto request)
        {
            var result = await _service.ProcessAsync(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            Console.WriteLine(result.Message);
            return Ok(result);
        }
    }
}
