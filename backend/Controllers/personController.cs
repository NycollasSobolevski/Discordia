using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security_jwt;
using System.Text;

namespace backend.Controllers;

using backend.Model;
using backend.Password;
using backend.Data;

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
    public async Task<ActionResult<Jwt>> Login(
        [FromBody] LoginData login,
        [FromServices] IJwtService jwtService
        )
    {
        var people = this.context.People
            .Where(x => x.Name == login.Indentify || x.Email == login.Indentify)
            .FirstOrDefault();

        if (people == null)
            return NotFound();

        if (PasswordConfig.GetHash(login.Password, people.Salt) != people.Password)
            return Unauthorized();

        ReturnLoginData user = new ReturnLoginData
        {
            IdPerson = people.Id
        };

        string jwt = jwtService.GetToken(user);

        return Ok(new Jwt() { Value =  jwt });
    }

    [HttpPost("addUser")]
    public ActionResult batatinha([FromBody] Person login)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        login.Salt = PasswordConfig.GenerateStringSalt(12);
        login.Password = PasswordConfig.GetHash(login.Password, login.Salt);

        this.context.People.Add(login);
        this.context.SaveChanges();
        return Ok();
    }

    [HttpPost("userData")]
    public string ReturnUserData(
        [FromBody]Jwt jwt,
        [FromServices] IJwtService jwtService
    ){
        
        string idUser = jwtService.Validate<string>(jwt.Value);
        return idUser;
    }
}


