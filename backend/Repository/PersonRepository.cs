using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

public class PersonRepository : IRepository<Person>
{
    private DiscordiaContext entity;
    public PersonRepository(DiscordiaContext entity)
        => this.entity = entity;


    public async Task add(Person obj)
    {
        await this.entity.People.AddAsync(obj);
        await this.entity.SaveChangesAsync();
    }

    public void Delete(Person obj)
    {
        throw new NotImplementedException();
    }
    public void Update(Person obj)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Person>> Filter(Expression<Func<Person, bool>> exp)
    {
        return await entity.People
            .Where(exp).ToListAsync();
    }

    public Task<Person> FirstOrDefault(Expression<Func<Person, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Person> Last(Person obj)
    {
        throw new NotImplementedException();
    }

    public Task<bool> exists(Person obj)
    {
        throw new NotImplementedException();
    }
}