
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

    [HttpGet("GetAllForuns")]
    public async Task<ActionResult<IEnumerable<Forum>>> GetAllForuns(
        [FromServices]IForumRepository forum,
        [FromServices]IPersonRepository personRepository,
        [FromServices]IRepository<Subscribed> subsRepository,
        [FromServices]IRepository<Post> postRepository
        )
    {
        var forums = await forum.Filter(x => true);

        // var result = forums.Select(forum => new ForumToFront{
        //     Creator = await personRepository.FirstOrDefault(person => person.Id == forum.CreatorId).Name,
        // });
        var list = new List<ForumToFront>();
        foreach(var f in forums)
        {
            var forumData = new ForumToFront() {
                Creator = personRepository.NewFirstOrDefault(person => person.Id == f.CreatorId).Name,
                Description = f.Description,
                Title = f.Title,
                Created = f.Created,
                // followers = subsRepository.Count(subs => subs.IdForum == f.Id),
                // posts = postRepository.Count(post => post.IdForum == f.Id) ,
            };

            list.Add(forumData);
        }

        return Ok(list);

    }

    [HttpPost("GetForumPage")]
    public async Task<ActionResult<ForumWithPosts>> GetForum(
        [FromBody] ForumData data,
        [FromServices]IForumRepository forumRepository,
        [FromServices]IPersonRepository personRepository,
        [FromServices]IRepository<Post> postRepository
        )
    {
        Forum forum  = await forumRepository.FirstOrDefault(forum => forum.Title == data.Title);

        List<PostData> postList = new List<PostData>();

        var posts = await postRepository.Filter(post => post.IdForum == forum.Id);
        foreach (var post in posts )
            postList.Add(new PostData{
                Title = post.Title,
                ForumTitle = forum.Title,
                Content = post.Content,
                Attachment = post.Attachment
            });

        if (forum == null)
            return BadRequest("Forum not exists");

        return Ok(new ForumWithPosts{
            Creator = personRepository.NewFirstOrDefault(person => person.Id == forum.CreatorId).Name,
            Title = forum.Title,
            Description = forum.Description,
            Created = forum.Created,
            Posts = postList
        });
    }
    [HttpGet("GetForumPage/{name}")]
    public async Task<ActionResult<ForumWithPosts>> GetForum(
        string name,
        [FromServices]IForumRepository forumRepository,
        [FromServices]IPersonRepository personRepository,
        [FromServices]IRepository<Post> postRepository
        )
    {
        Forum forum  = await forumRepository.FirstOrDefault(forum => forum.Title == name);

        List<PostData> postList = new List<PostData>();

        var posts = await postRepository.Filter(post => post.IdForum == forum.Id);
        foreach (var post in posts )
            postList.Add(new PostData{
                Title = post.Title,
                ForumTitle = forum.Title,
                Content = post.Content,
                Attachment = post.Attachment
            });

        if (forum == null)
            return BadRequest("Forum not exists");

        return Ok(new ForumWithPosts{
            Creator = personRepository.NewFirstOrDefault(person => person.Id == forum.CreatorId).Name,
            Title = forum.Title,
            Description = forum.Description,
            Created = forum.Created,
            Posts = postList
        });
    }
}

