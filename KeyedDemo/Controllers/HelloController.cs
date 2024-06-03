using KeyedDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedDemo.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class HelloController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly FriendsService _friendsService;

        public HelloController(CustomerService customerService, FriendsService friendsService)
        {
            _customerService = customerService;
            _friendsService = friendsService;
        }

        [HttpGet]
        [ActionName("GreetCustomer")]
        public IActionResult GreetCustomer()
        {
            return Ok(_customerService.Greet());
        }

        [HttpGet]
        [ActionName("GreetFriend")]
        public IActionResult GreetFriend()
        {
            return Ok(_friendsService.Greet());
        }
    }
}
