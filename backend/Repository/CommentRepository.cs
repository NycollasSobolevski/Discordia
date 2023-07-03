using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using System.Linq;
using Model;

public class CommentRepository : IRepository<Comment>
{
    private DiscordiaContext entity;
    public async Task add(Comment obj)
        => await entity.Comments.AddAsync(obj);

    public void Delete(Comment obj)
        => entity.Comments.Remove(obj);

    public bool exists(Comment obj)
    {
        throw new NotImplementedException();
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
        => entity.Comments.Update(obj);

    Task<Comment> IRepository<Comment>.Last(Comment obj)
    {
        throw new NotImplementedException();
    }
}