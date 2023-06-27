using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class PostRepository : IRepository<Post>
{
    private DiscordiaContext entity;
    public void add(Post obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Post obj)
    {
        
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public async Task<List<Post>> Filter(Expression<Func<Post, bool>> exp)
    {
        return await entity.Posts
            .Where(exp)
            .ToListAsync();
    }

    public void Update(Post obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}