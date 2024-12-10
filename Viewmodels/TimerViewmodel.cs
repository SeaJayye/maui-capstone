using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

public class TimersViewModel
{
    public ObservableCollection<TimerModel> ActiveTimers { get; set; }

    public TimersViewModel()
    {
        ActiveTimers = new ObservableCollection<TimerModel>();
    }

    public void IncreaseTime(TimerModel timer, TimeSpan amount)
    {
        timer.RemainingTime += amount;
        timer.OriginalDuration += amount;
    }

    public void DecreaseTime(TimerModel timer, TimeSpan amount)
    {
        if (timer.RemainingTime > amount)
        {
            timer.RemainingTime -= amount;
            timer.OriginalDuration -= amount;
        }
        else
        {
            timer.RemainingTime = TimeSpan.Zero;
            timer.OriginalDuration = TimeSpan.Zero;
        }
    }

    public void AddTimer(string timerName, TimeSpan initialTime)
    {
        ActiveTimers.Add(new TimerModel { TimerName = timerName, RemainingTime = initialTime, OriginalDuration = initialTime});
    }

    public void UpdateTimerName(TimerModel timer, string newName)
    {
        timer.TimerName = newName;
    }
}

public class TimerModel : INotifyPropertyChanged
{
    private string timerName;
    private TimeSpan remainingTime;

    private TimeSpan originalDuration;

    public TimeSpan OriginalDuration
    {
        get => originalDuration;
        set
        {
            originalDuration = value;
            OnPropertyChanged(nameof(OriginalDuration));
        }
    }

    public string TimerName
    {
        get => timerName;
        set
        {
            timerName = value;
            OnPropertyChanged(nameof(TimerName));
        }
    }

    public TimeSpan RemainingTime
    {
        get => remainingTime;
        set
        {
            remainingTime = value;
            OnPropertyChanged(nameof(RemainingTime));
        }
    }

    public System.Timers.Timer TimerInstance { get; internal set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}