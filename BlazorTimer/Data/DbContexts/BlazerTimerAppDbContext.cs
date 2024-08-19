using BlazorTimer.Modals;
using Microsoft.EntityFrameworkCore;

namespace BlazorTimer.Data.DbContexts;

public class BlazerTimerAppDbContext : DbContext
{
    public BlazerTimerAppDbContext(DbContextOptions<BlazerTimerAppDbContext> options) : base(options)
    {
    }

    public DbSet<TimerInfo> TimerInfos { get; set; }
}
