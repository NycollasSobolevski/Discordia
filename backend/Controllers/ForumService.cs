
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
    public async Task<ActionResult<IEnumerable<Forum>>> GetForumsUserFollowed(
        [FromBody]Jwt userData,
        [FromServices]IJwtService jwtService,
        [FromServices]IForumRepository forumRepository
        )
    {

        var result = jwtService.Validate<ReturnLoginData>(userData.Value);
        var id = result.IdPerson;

        Person user = await this.context.People.FirstOrDefaultAsync(users => users.Id == id);

        if (user is null)
            return Ok("User not found");

        var forums = await forumRepository.GetUserForums(user);

        var forumResult = forums
            .Select(f => new ForumToFront() {
                Creator = f.Creator.Name,
                Title = f.Title,
                Description = f.Description,
                Created = f.Created
            }).ToList();
        // var jsonString = JsonConvert.SerializeObject(forums);

        return Ok(forumResult);

    }


    [HttpPost("createForum")]
    public async Task<ActionResult> CreateForum(
        [FromBody]ForumData forum,
        [FromServices]IForumRepository forumRepo,
        [FromServices]IRepository<Position> positionRepo,
        [FromServices]IRepository<Subscribed> subRepo,
        [FromServices]IJwtService jwtService
        )
    {

        var result = jwtService.Validate<ReturnLoginData>( forum.CreatorIdJwt );
        var id = result.IdPerson;

        Forum newForum = new Forum{
            CreatorId = id,
            Title = forum.Title,
            Description = forum.Description,
            Created = DateTime.Now
        };

        int response = await forumRepo.addAsync( newForum );
        if (response == 409)
            return BadRequest("Forum Exists");
        System.Console.WriteLine(response);
        return Ok("Successful Forum Creation");
    }


    [HttpPost("GetAllForuns")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetAllForuns(
        [FromServices]IForumRepository forum
        )
        => await forum.Filter(x => true);



}

