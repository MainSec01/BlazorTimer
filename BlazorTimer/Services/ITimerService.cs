using System.Linq.Expressions;
using ActualLab.Fusion;
using BlazorTimer.Modals;
using BlazorTimer.Services.DTOs;

namespace BlazorTimer.Services;

public interface ITimerService : IDisposable, IComputeService
{
    Task<TimerInfoForCreation> SaveAsync(TimerInfoForCreation timerInfo);
    IEnumerable<TimerInfo> GetAllAsync(Expression<Func<TimerInfo, bool>> expression = null);
}
