using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Security_jwt;


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
    public async Task<ActionResult<string>> Login(
        [FromBody]LoginData login,
        [FromServices]IJwtService jwtService
        ){
        
        var people = this.context.People
            .Where(x => x.Name == login.Indentify || x.Email == login.Indentify)
            .FirstOrDefault();
        
        if(people == null)
            return StatusCode(401);
        if(PasswordConfig.GetHash(login.Password, people.Salt) != people.Password)
            return StatusCode(401);
        
        ReturnLoginData user = new ReturnLoginData{
            IdPerson = people.Id
        };
        
        return jwtService.GetToken(user);   
    }

    [HttpPost("addUser")]
    public ActionResult batatinha([FromBody]Person login){
        if (!ModelState.IsValid)
            return BadRequest();

        login.Salt = PasswordConfig.GenerateStringSalt(12);
        login.Password = PasswordConfig.GetHash(login.Password, login.Salt);

        this.context.People.Add(login);
        this.context.SaveChanges();
        return Ok();
    }
}


