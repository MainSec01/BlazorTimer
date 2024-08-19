using BlazorTimer.Modals.Commons;

namespace BlazorTimer.Modals;

public class TimerInfo : Auditble
{
    public string MAC { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public Status Status { get; set; }
}
