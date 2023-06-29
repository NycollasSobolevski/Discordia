
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

using backend.Model;
using backend.Data;

[ApiController]
[Route("forum")]
[EnableCors("MainPolicy")]
public class ForumController : ControllerBase
{
    private DiscordiaContext context;
    public ForumController(DiscordiaContext context)
        => this.context = context;


    [HttpPost("getUserForumsFollowed")]
    public IEnumerable<Forum> GetForumsUserFollowed
        ([FromBody]UserData userData)
    {
        Person user = this.context.People.Where(users => users.Email == userData.Email).FirstOrDefault();
        var forums = this.context.Forums.Where(f => f.CreatorId == user.Id);

        return forums;
    }


    [HttpPost("createForum")]
    public ActionResult CreateForum(
        [FromBody]ForumData forum,
        [FromServices]IJwtService jwtService
        )
    {
        var result = jwtService.Validate<ReturnLoginData>(forum.CreatorIdJwt);

        var id = result.IdPerson;

        Forum newForum = new Forum{
            CreatorId = id,
            Title = forum.Title,
            Description = forum.Description,
            Created = DateTime.Now
        };

        this.context.Forums.Add(newForum);
        this.context.SaveChanges();
        return Ok();
    }
}