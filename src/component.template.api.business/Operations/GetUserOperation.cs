using component.template.api.domain.Common;
using component.template.api.domain.Models.Common;

namespace component.template.api.business.Operations;

public class GetUserOperation : BaseOperation<EmptyRequest, EmptyResponse>
{
    public override async Task<EmptyResponse> RunAsync(EmptyRequest input)
    {
        return await Task.FromResult(new EmptyResponse());
    }

    public override async Task ValidateAsync(EmptyRequest input)
    {
        await Task.CompletedTask;
    }
}
