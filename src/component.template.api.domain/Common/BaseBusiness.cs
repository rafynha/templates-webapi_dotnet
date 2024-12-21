using component.template.api.domain.Helpers;
using component.template.api.domain.Interfaces.Business.Common;
using component.template.api.domain.Interfaces.Infrastructure.Repository.Common;
using component.template.api.domain.Models.Common;

namespace component.template.api.domain.Common;

public abstract class BaseBusiness
{
    protected Dictionary<System.Type, IBusinessServices> _services { get; set; } = new();
    protected HttpContextAccessInfo _contextAccessInfo { get; set; }

    public BaseBusiness()
    {
        this._contextAccessInfo = HttpHelper.HttpContext.Items[nameof(HttpContextAccessInfo)] as HttpContextAccessInfo;
    }

    public virtual void RegisterBusinessServicesDependencies(List<IBusinessServices> services = null, IUnitOfWork unitOfWork = null)
    {
        if(services != null)
            foreach (var item in services)
            {
                _services.Add(item?.GetType()?.GetInterfaces()?.FirstOrDefault() ?? item.GetType(), item);
                
                if(HttpHelper.HttpContext.Items[item.GetType().Name] == null)
                    HttpHelper.AddContextItem<IBusinessServices>(item.GetType().GetInterfaces().FirstOrDefault().Name, item);
            }
        if(unitOfWork != null && HttpHelper.HttpContext.Items[unitOfWork.GetType().GetInterfaces().FirstOrDefault().Name] == null)
             HttpHelper.AddContextItem<IUnitOfWork>(unitOfWork.GetType().GetInterfaces().FirstOrDefault().Name, unitOfWork);
    }
}
