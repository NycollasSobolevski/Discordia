using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace backend.Controllers;

using backend.Model;
using backend.Password;

#pragma warning disable

[ApiController]
[Route("user")]
[EnableCors("MainPolicy")]
public class personController : ControllerBase
{
    private DiscordiaContext context;
    public personController(DiscordiaContext context) 
        => this.context = context;

    [HttpPost("login")]
    public Person? batata([FromBody]Person login){
        return this.context.People
            .Where(x => x.Name == login.Name || x.Email == login.Email && x.Password == login.Password)
            .FirstOrDefault();
    }

    [HttpPost("addUser")]
    public ActionResult batatinha([FromBody]Person login){
        if (!ModelState.IsValid)
            return BadRequest();

        login.Salt = passwordConfig.getStringSalt(12);


        this.context.People.Add(login);
        this.context.SaveChanges();
        return Ok();
    }
}


