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
    }

    public void DecreaseTime(TimerModel timer, TimeSpan amount)
    {
        if (timer.RemainingTime > amount)
        {
            timer.RemainingTime -= amount;
        }
        else
        {
            timer.RemainingTime = TimeSpan.Zero;
        }
    }

    public void AddTimer(string timerName, TimeSpan initialTime)
    {
        ActiveTimers.Add(new TimerModel { TimerName = timerName, RemainingTime = initialTime });
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}