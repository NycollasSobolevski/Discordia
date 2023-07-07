using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;


public interface IPostRepository : IRepository<Post>
{
    public Task<List<Post>> GetUserForumFollowedPosts (Person user, int quantity, int page);
}


public class PostRepository : IPostRepository
{
    private DiscordiaContext entity;

    public PostRepository( DiscordiaContext service) 
        => this.entity = service;


    public async Task add(Post obj)
    {
        obj.Attachment = false;

        await entity.Posts.AddAsync(obj);
        await entity.SaveChangesAsync();
    }

    public  int Count(Expression<Func<Post, bool>> exp)
    {
        return entity.Posts.Select(exp).Count();
    }

    public void Delete(Post obj)
    {
        
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public Task<bool> exists(Post obj)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Post>> Filter(Expression<Func<Post, bool>> exp)
    {
        return await entity.Posts
            .Where(exp)
            .ToListAsync();
    }

    public Task<Post> FirstOrDefault(Expression<Func<Post, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Last(Post obj)
    {
        throw new NotImplementedException();
    }

    public void Update(Post obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }

    public async Task<List<Post>> GetUserForumFollowedPosts (Person user,  int page, int quantity)
    {
        var query = 
            from s in entity.Subscribeds
            where s.IdPerson == user.Id
            join f in entity.Forums
            on s.IdForum equals f.Id
            join p in entity.Posts
            on f.Id equals p.IdForum
            select p;
        
        var posts = await query
            .Skip(quantity * page)
            .Take(quantity)
            .ToListAsync();
        
        Console.WriteLine(posts.Count);

        return posts;
    }

}