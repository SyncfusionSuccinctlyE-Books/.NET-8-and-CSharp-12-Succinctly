using Microsoft.AspNetCore.Mvc;
using WebApiStuff.Services;

namespace WebApiStuff.Controllers
{

    [ApiController]
    [Route("api/[action]")]
    public class TimeController : Controller
    {
        private readonly TimeService _timeService;
        private readonly TaskRunnerService _taskRunnerService;

        public TimeController(TimeService timeService, TaskRunnerService taskRunnerService)
        {
            _timeService = timeService;
            _taskRunnerService = taskRunnerService;
        }


        [HttpGet]
        [ActionName("RunMorningTasks")]
        public IActionResult Get()
        {

            var isMorning = _timeService.RunMorningTasks();
            if(isMorning)
            {
                var duration = _taskRunnerService.MorningTaskRunner();
                return Ok($"Ran morning tasks - duration {duration}");
            }
                        
            return Ok("Morning tasks not scheduled to run");
        }
    }
}
