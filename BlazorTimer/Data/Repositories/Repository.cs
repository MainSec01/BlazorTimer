using BlazorTimer.Data.DbContexts;
using BlazorTimer.Data.IRepositories;
using BlazorTimer.Modals;
using BlazorTimer.Modals.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorTimer.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditble
{
    private readonly BlazerTimerAppDbContext dbContext;
    private readonly DbSet<T> dbSet;
    
    
    public Repository(BlazerTimerAppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<T>();
    }

    public async Task<T> CreateTimerAsync(T timer) =>
        (await dbContext.AddAsync(timer)).Entity;

    public IQueryable<T> GetAllTimers(Expression<Func<T, bool>> expression = null) 
        =>    expression is null ? dbSet.Where(exp => true) : dbSet.Where(expression);


    public async ValueTask SaveChangesAsync() =>
        await dbContext.SaveChangesAsync();
}
