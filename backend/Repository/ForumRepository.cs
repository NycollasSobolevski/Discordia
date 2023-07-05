using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public interface IForumRepository : IRepository<Forum>
{
    Task<List<Forum>> GetUserForums(Person person);
    Task<int> addAsync( Forum obj );
}


public class ForumRepository : IForumRepository
{
    private DiscordiaContext entity;
    public ForumRepository( DiscordiaContext service) 
        => this.entity = service;

    
    public async Task<List<Forum>> Filter(Expression<Func<Forum, bool>> exp)
    {
        return await entity.Forums
            .Where(exp)
            .ToListAsync();
    }
    public async Task<List<Forum>> GetAllForums(Expression<Func<Forum, bool>> exp)
    {
        return await entity.Forums.Where(exp).ToListAsync();
    }
    public async Task<Forum> FirstOrDefault(Expression<Func<Forum, bool>> exp)
        => await entity.Forums.FirstOrDefaultAsync(exp);


    public async Task<List<Forum>> GetUserForums(Person user)
    {
        var groups = entity.Subscribeds
            .Where(s => s.IdPerson == user.Id)
            .Select(s => s.IdForumNavigation);

        return await groups.ToListAsync();
    }

    public Task add( Forum obj )
    {
        throw new NotImplementedException();
    }
    public async Task<int> addAsync( Forum obj )
    {
        bool verify = await this.exists(obj);
        if(verify)
            return 409;

        await entity.Forums.AddAsync( obj );

        await entity.SaveChangesAsync();
        Position newAdmin = new Position{
            IdForum = obj.Id,
            Name = "Admin"
        };

        await entity.Positions.AddAsync(newAdmin);
        await entity.SaveChangesAsync();

        Position newUser = new Position{
            IdForum = obj.Id,
            Name = "User"
        };
        await entity.Positions.AddAsync(newUser);

        Subscribed newSub = new Subscribed{
            IdPerson = obj.CreatorId,
            IdPosition = newAdmin.Id,
            IdForum = obj.Id
        };

        for (int i = 1; i <= 10; i++)
        {
            Permission adminFuncs = new Permission{
                IdFuncs = i,
                IdPosition = newAdmin.Id
            };
            Permission userFuncs = new Permission{
                IdFuncs = i,
                IdPosition = newAdmin.Id
            };

            if(i != 7 || i != 8 || i != 9 || i != 10)
                await entity.Permissions.AddAsync(userFuncs);
            
            await entity.Permissions.AddAsync(adminFuncs);
            await entity.SaveChangesAsync();
        }

        await entity.Subscribeds.AddAsync(newSub);
        await entity.SaveChangesAsync();
        return 200;
    }

    public void Delete( Forum obj )
    {
        entity.Forums.Remove(obj);
        entity.SaveChanges();
    }
    

    public void Update( Forum obj )
    {
        entity.Forums.Update(obj);
        entity.SaveChanges();
    }

    public async Task<Forum> Last( Forum obj )
        => await entity.Forums
            .Where(forum => forum.Title == obj.Title)
            .OrderBy(x => x.Created)
            .LastOrDefaultAsync();

    public async Task<bool> exists( Forum obj )
    {
        var result = await entity.Forums.Where( forum => forum.Title == obj.Title ).ToListAsync();
        if (result.Count > 0)
            return true;
        return false;
    }

    public int Count(Expression<Func<Forum, bool>> exp)
    {
        throw new NotImplementedException();
    }

}