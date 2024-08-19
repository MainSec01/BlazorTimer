using BlazorTimer.Modals;
using System.Linq.Expressions;

namespace BlazorTimer.Data.IRepositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAllTimers(Expression<Func<T, bool>> expression = null);
    Task<T> CreateTimerAsync(T timer);
    ValueTask SaveChangesAsync();
}
