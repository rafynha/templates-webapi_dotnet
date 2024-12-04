using component.template.api.domain.Interfaces.Infrastructure.Repository;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.Repository.Contexts;

namespace component.template.api.infrastructure.Repository.Common;

public class UnitOfWorkForSql : IUnitOfWork
{
    private readonly SqlContext _context;

    public IUserRepository Users { get; }
    public IProfileRepository Profiles { get; }
    public IPermissionRepository Permissions { get; }
    public IUserProfileRepository UserProfiles { get; }
    public IProfilePermissionRepository ProfilePermissions { get; }

    public UnitOfWorkForSql(SqlContext context,
                      IUserRepository users,
                      IProfileRepository profiles,
                      IPermissionRepository permissions,
                      IUserProfileRepository userProfiles,
                      IProfilePermissionRepository profilePermissions)
    {
        _context = context;
        Users = users;
        Profiles = profiles;
        Permissions = permissions;
        UserProfiles = userProfiles;
        ProfilePermissions = profilePermissions;
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        if (_context.Database.CurrentTransaction == null)
        {
            await _context.Database.BeginTransactionAsync();
        }
    }

    public async Task CommitTransactionAsync()
    {
        var transaction = _context.Database.CurrentTransaction;
        if (transaction != null)
        {
            await transaction.CommitAsync();
        }
    }

    public async Task RollbackAsync()
    {
        var transaction = _context.Database.CurrentTransaction;
        if (transaction != null)
        {
            await transaction.RollbackAsync();
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}