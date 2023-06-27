using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("user")]
public class personController : ControllerBase
{
    [HttpGet("{user}")]
}