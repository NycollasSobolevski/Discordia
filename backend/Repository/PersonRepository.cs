using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using Model;

public class PersonRepository : IRepository<Person>
{
    private DiscordiaContext entity;
    public void add(Person obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Person obj)
    {
        
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public async Task<List<Person>> Filter(Expression<Func<Person, bool>> exp)
    {
        return await entity.People
            .Where(exp)
            .ToListAsync();
    }

    public void Update(Person obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}