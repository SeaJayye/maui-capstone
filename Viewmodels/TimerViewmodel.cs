using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

public class TimersViewModel
{
    public ObservableCollection<TimerModel> ActiveTimers { get; set; }

    public TimersViewModel()
    {
        // Sample data
        ActiveTimers = new ObservableCollection<TimerModel>
        {
            new TimerModel { TimerName = "Timer 1", RemainingTime = TimeSpan.FromMinutes(10) },
            new TimerModel { TimerName = "Timer 2", RemainingTime = TimeSpan.FromMinutes(25) },
            new TimerModel { TimerName = "Timer 3", RemainingTime = TimeSpan.FromMinutes(5) }
        };
    }
}

public class TimerModel
{
    public string TimerName { get; set; }
    public TimeSpan RemainingTime { get; set; }

}