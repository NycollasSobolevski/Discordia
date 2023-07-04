using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers;

using backend.Model;
using backend.Data;

[ApiController]
[Route("post")]
[EnableCors("MainPolicy")]
public class PostController : ControllerBase
{
    [HttpPost("createPost")]
    public async Task<ActionResult> Post(
        [FromBody] PostData post,
        [FromServices] IRepository<Post> postRepository,
        [FromServices] IForumRepository forumRepository,
        [FromServices] IJwtService jwtService
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
}