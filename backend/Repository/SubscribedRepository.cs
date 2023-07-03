using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class SubscribedRepository : IRepository<Subscribed>
{
    private DiscordiaContext entity;
    public async Task add(Subscribed obj)
    {
        await entity.Subscribeds.AddAsync(obj);
        await entity.SaveChangesAsync();

    }

    public void Delete(Subscribed obj)
    {
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public bool exists(Subscribed obj)
    {
        throw new NotImplementedException();
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

    public void Update(Subscribed obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}