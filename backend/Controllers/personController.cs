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
public class PersonController : ControllerBase
{
    [HttpPost("GetPermissions")]
    public async Task<ActionResult<IEnumerable<Func>>> Post(
        [FromBody] PermissionData body,
        [FromServices] IJwtService jwtService,
        [FromServices] ISubscribedRepository postRepository
        )
    {
        var userjwt = jwtService.Validate<ReturnLoginData>(body.jwt);
        int idUser = userjwt.IdPerson;

        return Ok(postRepository.VerifyPermission( idUser, body.ForumName ));
    }

    [HttpPost("login")]
    public async Task<ActionResult<Jwt>> Login(
        [FromBody] LoginData login,
        [FromServices] IPersonRepository personRepository,
        [FromServices] IJwtService jwtService
        )
    {
        var people = personRepository
            .NewFirstOrDefault(x => 
                x.Name.Contains(login.Indentify) 
                || x.Email == login.Indentify
                );

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
    public ActionResult UserRegister(
        [FromBody] Person login,
        [FromServices] IPersonRepository personRepository
        )
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Person? peopleIfExists = personRepository
            .NewFirstOrDefault(person => 
                person.Name == login.Name || 
                person.Email == login.Email);

        if (peopleIfExists != null)
        {
            if (peopleIfExists.Name == login.Name)
                return BadRequest("this username already exists");
            if (peopleIfExists.Email == login.Email)
                return BadRequest("This email already exists");
        
        }

        login.Salt = PasswordConfig.GenerateStringSalt(12);
        login.Password = PasswordConfig.GetHash(login.Password, login.Salt);

        personRepository.add(login);
        return Ok();
    }

    [HttpPost("userData")]
    public ActionResult<UserData> ReturnUserData(
        [FromBody]Jwt jwt,
        [FromServices] IPersonRepository userRepository,
        [FromServices] IJwtService jwtService
    ){
        
        var idUser = jwtService.Validate<ReturnLoginData>(jwt.Value);

        var user = userRepository.NewFirstOrDefault(user => user.Id == idUser.IdPerson);


        return Ok( new UserData{
            UserName = user.Name,
            Email = user.Email,
            Birthday = user.Birth
        } );
    }
}


