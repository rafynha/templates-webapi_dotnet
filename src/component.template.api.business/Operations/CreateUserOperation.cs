using component.template.api.domain.Common;
using component.template.api.domain.Helpers;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.Common;
using component.template.api.domain.Models.External;

namespace component.template.api.business.Operations;

public class CreateUserOperation : BaseOperation<CreateUserRequest, CreateUserResponse>
{
    public override async Task<CreateUserResponse> RunAsync(CreateUserRequest input)
    {
        /* Call Service example */
        // var contextService = GetContextService<IWeatherForecastBusiness>();
        // var resultService = await contextService.GetAll();        

        var repo = base.GetContextRepositories<IUnitOfWork>();

        var existingUser = await repo.Users
                .GetAllAsync();

        return await Task.FromResult(new CreateUserResponse());
    }

    public override async Task ValidateAsync(CreateUserRequest input)
    {
        await Task.CompletedTask;
    }
}
