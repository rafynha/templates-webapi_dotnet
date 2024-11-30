using System;

namespace component.template.api.domain.Interfaces;

public interface IApiResponse<T>
{
    public List<BaseError> Errors { get; set; }
    T Data { get; set; }
}
