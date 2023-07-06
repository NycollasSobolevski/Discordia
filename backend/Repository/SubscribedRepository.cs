using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public interface ISubscribedRepository : IRepository<Subscribed>
{
    Task<IEnumerable<Func>> VerifyPermission(int IdPerson, string ForumName);
}

public class SubscribedRepository : ISubscribedRepository
{
    private DiscordiaContext entity;

    public SubscribedRepository(DiscordiaContext entity)
    {
        this.entity = entity;
    }

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

    public async Task<IEnumerable<Func>> VerifyPermission( int IdPerson, string ForumName )
    {
        var forum = entity.Forums
            .FirstOrDefault(x => x.Title == ForumName);
    
        var query =
            from subs in entity.Subscribeds
            join pos in entity.Positions on subs.IdPosition equals pos.Id
            join per in entity.Permissions on pos.Id equals per.IdPosition
            join func in entity.Funcs on per.IdFuncs equals func.Id
            where subs.IdForum == forum.Id
            where subs.IdPerson == IdPerson
            select func;
        
        var permissionList = await query.ToListAsync();

        foreach (var x in permissionList)
            Console.WriteLine(x.Name);

        return permissionList;
    }
}