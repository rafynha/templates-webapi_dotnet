
namespace component.template.api.domain.Interfaces.Infrastructure.Repository.Common;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProfileRepository Profiles { get; }
    IUserProfileRepository UserProfiles { get; }
    IPermissionRepository Permissions { get; }
    IProfilePermissionRepository ProfilePermissions { get; }
    Task<int> CommitAsync();
    Task BeginTransactionAsync();
    Task RollbackAsync();
    Task CommitTransactionAsync();
}
