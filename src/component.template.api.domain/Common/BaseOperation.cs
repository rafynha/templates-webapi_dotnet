using System;
using AutoMapper;
using component.template.api.domain.Helpers;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.Common;

namespace component.template.api.domain.Common;

public abstract class BaseOperation<TInput, TOutput> : IBusinessOperation<TInput, TOutput>
    where TInput : new()
{
    protected Dictionary<System.Type, IBusinessServices> _services { get; set; }
    public HttpContextAccessInfo _contextAccessInfo { get; set; }
    public IMapper _mapper { 
        get 
        {
            return new MapperConfiguration(cfg => ConfigureMappings(cfg)).CreateMapper();
        } 
    }
    public abstract void ConfigureMappings(IMapperConfigurationExpression cfg);

    public Task<TOutput> ExecuteOperation(TInput input, Dictionary<System.Type, IBusinessServices> services = null)
    {
        this._contextAccessInfo = HttpHelper.HttpContext.Items[nameof(HttpContextAccessInfo)] as HttpContextAccessInfo;
        this._services = services ?? new Dictionary<System.Type, IBusinessServices>();

        this.ValidateAsync(input);
        return this.RunAsync(input);
    }

    public async Task<TOutput> ExecuteOperation(TInput input)
    {
        this._contextAccessInfo = HttpHelper.HttpContext.Items[nameof(HttpContextAccessInfo)] as HttpContextAccessInfo;

        await this.ValidateAsync(input);
        return await this.RunAsync(input);
    }

    public T GetService<T>() where T : IBusinessServices
    {
        if (_services?[typeof(T)] != null)
            return (T)_services[typeof(T)];

        return (T)(object)null;
    }

    public T GetContextService<T>() where T : IBusinessServices
    {
        if(HttpHelper.HttpContext.Items.TryGetValue(typeof(T)?.Name, out var service))
            return (T)service;
        
        return (T)(object)null;
    }

    public T GetContextRepositories<T>() where T : IUnitOfWork
    {
        if(HttpHelper.HttpContext.Items.TryGetValue(typeof(T)?.Name, out var repositories))
            return (T)repositories;
        
        return (T)(object)null;
    }

    public abstract Task ValidateAsync(TInput input);
    public abstract Task<TOutput> RunAsync(TInput input);
}