
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [FromBody]UserIdJwt userData,
        [FromServices]IJwtService jwtService,
        [FromServices]IRepository<Forum> forumRepository
        )
    {

        var result = jwtService.Validate<ReturnLoginData>(userData.JwT);
        var id = result.IdPerson;

        System.Console.WriteLine($"{result}\n\n{id}");
        var user = await this.context.People.FirstOrDefaultAsync(users => users.Id == id);

        if (user is null)
        {
            return Ok("User not found");
        }

        // var forums = await this.context.Forums.Where(forum => forum.CreatorId == id).ToListAsync();
        var forums = await forumRepository.Filter(x => x.CreatorId == id);

        System.Console.WriteLine($"{forums}\n\n{user}");


        return forums;
    }


    [HttpPost("createForum")]
    public async Task<ActionResult> CreateForum(
        [FromBody]ForumData forum,
        [FromServices]IRepository<Forum> forumRepo,
        [FromServices]IRepository<Position> positionRepo,
        [FromServices]IRepository<Subscribed> subRepo,
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

        forumRepo.add(newForum);

        var lastForum = await forumRepo.Last(newForum);
        try {
            this.newPositionAsForumCreated(lastForum, positionRepo);
        } catch {
            return BadRequest("Create Position Error!");
        }

        try{
            this.addSubscribedInAdmin(id, lastForum, subRepo,positionRepo );
        } catch {
            return BadRequest("Add admin error");
        }
        
        return Ok();
    }


    [HttpPost("GetAllForuns")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetAllForuns(
        [FromServices]IRepository<Forum> forum
        )
        => await forum.Filter(x => true);



    private void addSubscribedInAdmin(
        int id, Forum forum,
        [FromServices]IRepository<Subscribed> subRepo,
        [FromServices]IRepository<Position> positionRepo
        )
    {
        var adminPosition = positionRepo.FirstOrDefault(position =>
            position.IdForum == forum.Id &&
            position.Name == "Admin" ) ;
        
        Subscribed newSub = new Subscribed{
            Id = forum.Id,
            IdPerson = id,
            IdPosition = adminPosition.Id
        };

        subRepo.add(newSub);
    }

    private void newPositionAsForumCreated(
        Forum forum,
        [FromServices]IRepository<Position> positionRepo
        )
    {
        Position newAdmin = new Position{
            IdForum = forum.Id,
            Name = "Admin"
        };
        positionRepo.add(newAdmin);
        Position newUser = new Position{
            IdForum = forum.Id,
            Name = "User"
        };
        positionRepo.add(newUser);
    }
}

