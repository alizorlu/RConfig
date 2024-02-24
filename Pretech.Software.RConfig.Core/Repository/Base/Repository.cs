using Microsoft.EntityFrameworkCore;
using Pretech.Software.RConfig.Core.DBContext;
using Pretech.Software.RConfig.Core.Response;
using System.Linq.Expressions;

namespace Pretech.Software.RConfig.Core.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RConfigContext _context;

        public Repository(RConfigContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DBResponseBase<T>> AddAsync(T data)
        {
            DBResponseBase<T> result = new();
            try
            {
                var record = await _context.AddAsync<T>(data);
                var inserted = await _context.SaveChangesAsync();
                if (inserted > 0)
                {
                    result.Success(record.Entity);
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<IEnumerable<T>>> AllAsync()
        {
            DBResponseBase<IEnumerable<T>> result = new();
            try
            {
                var all = await _context.Set<T>().ToListAsync();
                result.Success(all);
            }
            catch (Exception ex)
            {

                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<bool>> DeleteAsync(object id)
        {
            DBResponseBase<bool> result = new();
            try
            {
                var find = await _context.Set<T>().FindAsync(id);
                if (find != null)
                {
                    _context.Set<T>().Remove(find);
                    var deleted = await _context.SaveChangesAsync();
                    if (deleted > 0)
                    {
                        result.Success(true);
                    }
                    else result.Error("Not found data");
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<T>> FindAsync(object id)
        {
            DBResponseBase<T> result = new();
            try
            {
                var find = await _context.Set<T>().FindAsync(id);
                if (find != null)
                {
                    result.Success(find);
                }
                else result.Error("Not found data");
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<T>> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            DBResponseBase<T> result = new();
            try
            {
                var find = await _context.Set<T>().FirstOrDefaultAsync(predicate);
                if (find != null)
                {
                    result.Success(find);
                }
                else result.Error("Not found data");
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<List<T>>> QueryAsync(Expression<Func<T, bool>> expression)
        {
            DBResponseBase<List<T>> result = new();
            try
            {
                var find = await _context.Set<T>().Where(expression).ToListAsync();
                if (find != null)
                {
                    result.Success(find);
                }
                else result.Error("Not found data");
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        public async Task<DBResponseBase<bool>> UpdateAsync(T data)
        {
            DBResponseBase<bool> result = new();
            try
            {
                var record = _context.Update<T>(data);
                var inserted = await _context.SaveChangesAsync();
                if (inserted > 0)
                {
                    result.Success(true);
                }
                else result.Error("");
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }
    }
}
