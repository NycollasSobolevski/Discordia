using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using System.Linq;
using Model;

public class CommentRepository : IRepository<Comment>
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

    public Task<Comment> FirstOrDefault(Expression<Func<Comment, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public void Update(Comment obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }

    Task<Comment> IRepository<Comment>.Last(Comment obj)
    {
        throw new NotImplementedException();
    }
}