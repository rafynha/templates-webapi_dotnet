using component.template.api.business.Operations;
using component.template.api.domain.Common;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.External;

namespace component.template.api.business.BusinessServices;

public class UserBusiness : BaseBusiness, IUserBusiness
{
    private readonly CreateUserOperation _createUserOperation = new();

    public UserBusiness(IUnitOfWork unitOfWork, IProfileBusiness profileBusiness)
    {
        RegisterBusinessServicesDependencies(
            new List<IBusinessServices> 
            { 
                this,
                profileBusiness                
            },
            unitOfWork);
    }

    public async Task<CreateUserResponse> Create(CreateUserRequest request) =>
        await _createUserOperation.ExecuteOperation(request);    
}
