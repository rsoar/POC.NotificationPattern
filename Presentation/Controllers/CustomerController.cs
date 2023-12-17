using Microsoft.AspNetCore.Mvc;
using NotificationPatternSample.Application.Interfaces;
using NotificationPatternSample.Presentation.DTOs.Request;

namespace NotificationPatternSample.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromServices] ICustomerService service, [FromBody] CreateCustomerRequest dto)
        {
            service.Create(dto);
            return Ok();
        }
    }
}
