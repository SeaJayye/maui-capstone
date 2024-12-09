using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using maui_capstone.Models;

namespace maui_capstone.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TimerViewModel> Timers { get; set; }
        public string NewTimerName { get; set; }
        private TimeSpan _newTimerDuration;
        public string NewTimerDuration
        {
            get => _newTimerDuration.ToString(@"hh\:mm\:ss");
            set
            {
                if (TimeSpan.TryParse(value, out var duration))
                {
                    _newTimerDuration = duration;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            Timers = new ObservableCollection<TimerViewModel>();
            NewTimerName = string.Empty;
            _newTimerDuration = TimeSpan.Zero;
            PropertyChanged = delegate { };
        }

        public ICommand AddTimerCommand => new Command(AddTimer);
        public ICommand IncreaseDurationCommand => new Command(IncreaseDuration);
        public ICommand DecreaseDurationCommand => new Command(DecreaseDuration);

        private void AddTimer()
        {
            var newTimer = new TimerModel { Name = NewTimerName, Duration = _newTimerDuration, EndTime = DateTime.Now.Add(_newTimerDuration) };
            Timers.Add(new TimerViewModel(newTimer));
        }

        private void IncreaseDuration()
        {
            _newTimerDuration = _newTimerDuration.Add(TimeSpan.FromMinutes(1));
            OnPropertyChanged(nameof(NewTimerDuration));
        }

        private void DecreaseDuration()
        {
            if (_newTimerDuration.TotalMinutes > 0)
            {
                _newTimerDuration = _newTimerDuration.Subtract(TimeSpan.FromMinutes(1));
                OnPropertyChanged(nameof(NewTimerDuration));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}