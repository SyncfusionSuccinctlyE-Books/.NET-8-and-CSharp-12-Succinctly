using DataAnnotationsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAnnotationsDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : Controller
{        
    [HttpPost("rangedemo")]
    public IActionResult RangeDemo([FromBody] RangeExampleModel body) 
        => !ModelState.IsValid ? BadRequest(ModelState) : Ok(body);

    [HttpPost("lengthdemo")]
    public IActionResult LengthDemo([FromBody] LengthExampleModel body) 
        => !ModelState.IsValid ? BadRequest(ModelState) : Ok(body);

    [HttpPost("allowedvaluesdemo")]
    public IActionResult AllowedValuesDemo([FromBody] AllowedValuesExampleModel body) 
        => !ModelState.IsValid ? BadRequest(ModelState) : Ok(body);

    [HttpPost("deniedvaluesdemo")]
    public IActionResult DeniedValuesDemo([FromBody] DeniedValuesExampleModel body) 
        => !ModelState.IsValid ? BadRequest(ModelState) : Ok(body);

    [HttpPost("base64demo")]
    public IActionResult Base64Demo([FromBody] Base64ExampleModel body) 
        => !ModelState.IsValid ? BadRequest(ModelState) : Ok(body);
}
