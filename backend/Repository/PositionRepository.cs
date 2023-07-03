using System.Linq.Expressions;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class PositionRepository : IRepository<Position>
{
    private DiscordiaContext entity;
    public PositionRepository(DiscordiaContext service) 
        => this.entity = service;

    public async Task add(Position obj)
    {
        await entity.AddAsync(obj);
        await entity.SaveChangesAsync();
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

    public async Task<Position> FirstOrDefault(Expression<Func<Position, bool>> exp)
        => await entity.Positions.FirstOrDefaultAsync(exp);

    public bool exists(Position obj)
    {
        throw new NotImplementedException();
    }
}