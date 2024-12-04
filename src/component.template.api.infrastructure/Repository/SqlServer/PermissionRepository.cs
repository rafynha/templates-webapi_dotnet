using component.template.api.domain.Interfaces.Infrastructure.Repository;
using component.template.api.domain.Models.Repository;
using component.template.api.domain.Models.Repository.Contexts;
using component.template.api.infrastructure.Repository.Common;

namespace component.template.api.infrastructure.Repository.SqlServer;

public class PermissionRepository : BaseRepository<PermissionDto>, IPermissionRepository
{
    public PermissionRepository(SqlContext context) : base(context) { }
}