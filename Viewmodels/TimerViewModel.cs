using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using maui_capstone.Models;

namespace maui_capstone.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private TimerModel _timerModel;

        public TimerViewModel(TimerModel timerModel)
        {
            PropertyChanged = delegate { };
            _timerModel = timerModel;
        }

        public string Name
        {
            get => _timerModel.Name;
            set
            {
                _timerModel.Name = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Duration
        {
            get => _timerModel.Duration;
            set
            {
                _timerModel.Duration = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndTime
        {
            get => _timerModel.EndTime;
            set
            {
                _timerModel.EndTime = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}