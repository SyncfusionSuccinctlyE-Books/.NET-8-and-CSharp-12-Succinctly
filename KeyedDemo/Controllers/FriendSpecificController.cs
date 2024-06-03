using KeyedDemo.Interfaces;
using KeyedDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedDemo.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class FriendSpecificController : Controller
    {

        private readonly IGreeter _greet;

        public FriendSpecificController([FromKeyedServices("friends")] IGreeter greet)
        {
            _greet = greet;
        }

        [HttpGet]
        [ActionName("GreetFriendSpecific")]
        public IActionResult GreetFriendSpecific(string friendName)
        {
            return Ok(_greet.Greeting($"Hey {friendName}. Nice to see you."));
        }
    }
}
