using BlazorTimer.Modals;

namespace BlazorTimer.Services.DTOs;

public class TimerInfoForCreation
{
    public string MAC { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Status Status { get; set; }
}
