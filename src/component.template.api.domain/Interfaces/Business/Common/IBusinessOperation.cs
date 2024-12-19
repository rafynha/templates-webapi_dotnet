using System;

namespace component.template.api.domain.Interfaces.Business.Common;

public interface IBusinessOperation<TInput,TOutput>
{
    abstract Task<TOutput> RunAsync(TInput input);
}
