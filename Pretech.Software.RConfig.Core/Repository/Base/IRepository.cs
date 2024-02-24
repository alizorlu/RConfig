using Pretech.Software.RConfig.Core.Response;
using System.Linq.Expressions;

namespace Pretech.Software.RConfig.Core.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task<DBResponseBase<IEnumerable<T>>> AllAsync();
        Task<DBResponseBase<T>> AddAsync(T data);
        Task<DBResponseBase<bool>> DeleteAsync(object id);
        Task<DBResponseBase<bool>> UpdateAsync(T data);
        Task<DBResponseBase<T>> FindAsync(object id);
        Task<DBResponseBase<T>> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<DBResponseBase<List<T>>> QueryAsync(Expression<Func<T, bool>> expression);
    }
}
