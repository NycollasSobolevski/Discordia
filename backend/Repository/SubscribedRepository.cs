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

    public Task<bool> exists(Subscribed obj)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Subscribed>> Filter(Expression<Func<Subscribed, bool>> exp)
    {
        return await entity.Subscribeds.Where(exp).ToListAsync();
    }
    public int Count(Expression<Func<Subscribed, bool>> exp)
    {
        return entity.Subscribeds.Select(exp).Count();
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