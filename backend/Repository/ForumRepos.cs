using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    
    public void add(Forum obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Forum obj)
    {
        entity.Remove(obj);
        entity.SaveChanges();
    }
    

    public void Update(Forum obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}