using KeyedDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeyedDemo.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class CustomerSpecificController : Controller
    {                
        [HttpGet]
        [ActionName("GreetCustomerSpecific")]
        public IActionResult GreetCustomerSpecific(string customerName)
        {
            var greeting = HttpContext.RequestServices
                .GetRequiredKeyedService<IGreeter>("customers")
                .Greeting($"Good day {customerName}. How many I assist you?");

            return Ok(greeting);
        }
    }
}
