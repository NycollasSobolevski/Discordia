using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers;

using backend.Model;
using backend.Data;
using System.Collections.Generic;

[ApiController]
[Route("post")]
[EnableCors("MainPolicy")]
public class PostController : ControllerBase
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

    [HttpPost("createPost")]
    public async Task<ActionResult> Post(
        [FromBody] PostData post,
        [FromServices] IRepository<Post> postRepository,
        [FromServices] IForumRepository forumRepository,
        [FromServices] IJwtService jwtService,
        [FromServices] ISubscribedRepository subsRepository
        )
    {
        System.Console.WriteLine(post);

        var result = jwtService.Validate<ReturnLoginData>( post.CreatorIdJwt );
        var id = result.IdPerson;



        var forum = await forumRepository.FirstOrDefault( forum => forum.Title == post.ForumTitle );

        if (forum == null)
            return BadRequest("Forum Not Found");

        Post newPost = new Post{
            Title = post.Title,
            Content = post.Content,
            CreatedAt = DateTime.Now,
            IdCreator = id,
            IdForum = forum.Id
        };

        await postRepository.add(newPost);

        return Ok("Successful Post Creation");
    }

    [HttpPost("GetUserPosts")]
    public async Task<ActionResult<IEnumerable<PostData>>> GetUserPostAsync (
        [FromBody] GetPostData data,
        [FromServices] IPersonRepository personRepository,
        [FromServices] IPostRepository postRepository,
        [FromServices] IForumRepository forumRepository,
        [FromServices] IJwtService jwtService
    )
    {

        var result = jwtService.Validate<ReturnLoginData>(data.Jwt);
        int Id = result.IdPerson;
        var user = personRepository.NewFirstOrDefault(person => person.Id == Id);

        var posts = await postRepository
            .GetUserForumFollowedPosts(
                user,
                data.Quantity > 0 ? data.Quantity : 10, 
                data.Page
            );
        
        IEnumerable<PostData> dtoPosts = posts.Select(p => new PostData
        {
            CreatorIdJwt = personRepository.NewFirstOrDefault( person => person.Id == p.IdCreator).Name,
            Content = p.Content,
            Title = p.Title,
            ForumTitle = forumRepository.NewFirstOrDefault(f => f.Id == p.IdForum).Title,
            Created = p.CreatedAt
        });

        return Ok(dtoPosts);
    }
}