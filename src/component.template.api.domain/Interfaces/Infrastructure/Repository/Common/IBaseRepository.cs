using System.Linq.Expressions;

namespace component.template.api.domain.Interfaces.Infrastructure.Repository.Common;

public interface IBaseRepository<T> where T : class
{
     Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
