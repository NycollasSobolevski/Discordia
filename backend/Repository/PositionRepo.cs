using System.Linq.Expressions;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class PositionRepo : IRepository<Position>
{
    private DiscordiaContext entity;
    public PositionRepo(DiscordiaContext service) 
        => this.entity = service;

    public void add(Position obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Position obj)
    {
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public async Task<List<Position>> Filter(Expression<Func<Position, bool>> exp)
    {
        return await entity.Positions
            .Where(exp)
            .ToListAsync();
    }

    public void Update(Position obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }

    public async Task<Position> Last(Position obj)
        => await entity.Positions.LastOrDefaultAsync( position => position.Name == obj.Name);

    public Task<Position> FirstOrDefault(Expression<Func<Position, bool>> exp)
    {
        throw new NotImplementedException();
    }
}