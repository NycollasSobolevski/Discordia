using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class ForumRepository : IRepository<Forum>
{
    private DiscordiaContext entity;
    public ForumRepository(DiscordiaContext service) 
        => this.entity = service;

    
    public async Task<List<Forum>> Filter(Expression<Func<Forum, bool>> exp)
    {
        return await entity.Forums
            .Where(exp)
            .ToListAsync();
    }
    public async Task<Forum> FirstOrDefault(Expression<Func<Forum, bool>> exp)
        => await entity.Forums.FirstOrDefaultAsync(exp);

    
    public async Task add(Forum obj)
    {
        await entity.Forums.AddAsync(obj);

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
            Id = obj.Id,
            IdPerson = obj.CreatorId,
            IdPosition = newAdmin.Id
        };

        
        await entity.SaveChangesAsync();
    }

    public void Delete(Forum obj)
    {
        entity.Forums.Remove(obj);
        entity.SaveChanges();
    }
    

    public void Update(Forum obj)
    {
        entity.Forums.Update(obj);
        entity.SaveChanges();
    }

    public async Task<Forum> Last(Forum obj)
        => await entity.Forums
            .Where(forum => forum.Title == obj.Title)
            .OrderBy(x => x.Created)
            .LastOrDefaultAsync();

    public bool exists(Forum obj)
    {
        // entity.
        return true;
    }
}