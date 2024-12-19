using System;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Models.External;

namespace component.template.api.domain.Interfaces.Business;

public interface IUserBusiness : IBusinessServices
{
    Task<CreateUserResponse> Create(CreateUserRequest request);
}
