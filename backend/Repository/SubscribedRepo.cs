using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class SubscribedRepository : IRepository<Comment>
{
    private DiscordiaContext entity;
    public void add(Comment obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Comment obj)
    {
        
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public async Task<List<Comment>> Filter(Expression<Func<Comment, bool>> exp)
    {
        return await entity.Comments
            .Where(exp)
            .ToListAsync();
    }

    public void Update(Comment obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}