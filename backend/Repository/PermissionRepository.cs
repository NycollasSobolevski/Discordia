


namespace backend;

using backend.Model;

public class PermissionRepository : IRepository<Permission>
{

    private DiscordiaContext entity;
    public PermissionRepository(DiscordiaContext service)
        => this.entity = service;

    public async Task add(Permission obj)
    {
        await entity.Permissions.AddAsync(obj);
        await entity.SaveChangesAsync();
    }
    public void Delete(Permission obj)
    {
        throw new NotImplementedException();
    }
    
    public void Update(Permission obj)
    {
        throw new NotImplementedException();
    }

    public Task<List<Permission>> Filter(System.Linq.Expressions.Expression<Func<Permission, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Permission> FirstOrDefault(System.Linq.Expressions.Expression<Func<Permission, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task<Permission> Last(Permission obj)
    {
        throw new NotImplementedException();
    }

    public Task<bool> exists(Permission obj)
    {
        throw new NotImplementedException();
    }
}