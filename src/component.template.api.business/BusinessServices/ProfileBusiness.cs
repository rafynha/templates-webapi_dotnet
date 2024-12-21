using component.template.api.business.Operations;
using component.template.api.domain.Common;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.External;

namespace component.template.api.business.BusinessServices;

public class ProfileBusiness : BaseBusiness, IProfileBusiness
{
    private readonly GetProfileByNameOperation _getProfileByNameOperation = new();
    public ProfileBusiness(IUnitOfWork unitOfWork)
    {;
        RegisterBusinessServicesDependencies(
            new List<IBusinessServices>
            {
                this
            },
            unitOfWork);
    }

    public async Task<GetProfileByNameResponse?> GetByName(GetProfileByNameRequest request) =>
        await _getProfileByNameOperation.ExecuteOperation(request);
}
