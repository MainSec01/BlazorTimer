using System.Linq.Expressions;
using ActualLab.CommandR.Configuration;
using ActualLab.Fusion;
using AutoMapper;
using BlazorTimer.Data.IRepositories;
using BlazorTimer.Modals;
using BlazorTimer.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorTimer.Services;

public class TimerService : ITimerService
{
    private readonly ServerConnectionRoutes _connectionRoutes;
    private readonly IRepository<TimerInfo> repository;
    private readonly IMapper mapper;
    public TimerService(IOptions<ServerConnectionRoutes> serverOptions, IRepository<TimerInfo> repository, IMapper mapper)
    {
        _connectionRoutes = serverOptions.Value;
        this.repository = repository;
        this.mapper = mapper;
    }

    public IEnumerable<TimerInfo> GetAllAsync(Expression<Func<TimerInfo, bool>> expression = null)
    {
        var allTimers = repository.GetAllTimers().ToList();

        return allTimers;
    }

    public async Task<TimerInfoForCreation> SaveAsync(TimerInfoForCreation timerInfo)
    {
        var newTimer = mapper.Map<TimerInfo>(timerInfo);
        var createdTimer = await  repository.CreateTimerAsync(newTimer);
        await repository.SaveChangesAsync();
        return  mapper.Map<TimerInfoForCreation>(createdTimer);

    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
