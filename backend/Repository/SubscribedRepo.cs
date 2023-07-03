using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class SubscribedRepository : IRepository<Subscribed>
{
    private DiscordiaContext entity;
    public void add(Comment obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void add(Subscribed obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(Comment obj)
    {
        
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public void Delete(Subscribed obj)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Comment>> Filter(Expression<Func<Comment, bool>> exp)
    {
        return await entity.Comments
            .Where(exp)
            .ToListAsync();
    }

    public Task<List<Subscribed>> Filter(Expression<Func<Subscribed, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Subscribed> FirstOrDefault(Expression<Func<Subscribed, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Subscribed> Last(Subscribed obj)
    {
        throw new NotImplementedException();
    }

    public void Update(Comment obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }

    public void Update(Subscribed obj)
    {
        throw new NotImplementedException();
    }
}