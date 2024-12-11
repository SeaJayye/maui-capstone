using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

namespace maui_capstone
{
    public partial class MainPage : ContentPage
    {
        private TimersViewModel viewModel;


        public MainPage()
        {
            InitializeComponent();
            viewModel = ((App)Application.Current).TimersViewModel; // Updated to use shared TimersViewModel instance
            BindingContext = viewModel; // Set BindingContext to viewModel
            viewModel.ActiveTimers.CollectionChanged += ActiveTimers_CollectionChanged; // Subscribe to CollectionChanged event
            Routing.RegisterRoute(nameof(TimerCreate), typeof(TimerCreate));

            var startAllButton = new Button
            {
                Text = "Start All Timers",
                BackgroundColor = (Color)Application.Current.Resources["Primary"],
                TextColor = (Color)Application.Current.Resources["PrimaryText"],
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            startAllButton.Clicked += StartAllTimers;
            // Add startAllButton to the page layout
        }

        GlobalIndex index = new GlobalIndex();
        private void ActiveTimers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var newItem in e.NewItems)
            {
                var timer = newItem as TimerModel;
                var frame = CreateTimerFrame(timer);
                if (index.count % 2 == 0) { TimerContainerEvens.Children.Add(frame); } // Add new frame to TimerContainerEvens
                else { TimerContainerOdds.Children.Add(frame); } // Add new frame to TimerContainer
                index.incr();
            }
        }

        private Frame CreateTimerFrame(TimerModel timer)
        {
            var frame = new Frame
            {
                BackgroundColor = (Color)Application.Current.Resources["Primary"],
                HasShadow = true,
                CornerRadius = 25,
                Margin = new Thickness(20),
                HeightRequest = 230,
                WidthRequest = 140,
                BorderColor = (Color)Application.Current.Resources["SecondaryLight"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            var nameLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = (Color)Application.Current.Resources["SecondaryText"]
            };
            nameLabel.SetBinding(Label.TextProperty, new Binding("TimerName", source: timer));

            var timeLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 16,
                TextColor = (Color)Application.Current.Resources["SecondaryText"]
            };
            timeLabel.SetBinding(Label.TextProperty, new Binding("RemainingTime", stringFormat: "{0:hh\\:mm\\:ss}", source: timer));

            var startButton = new Button
            {
                Text = "Start Timer",
                BackgroundColor = (Color)Application.Current.Resources["Primary"],
                TextColor = (Color)Application.Current.Resources["PrimaryText"],
                BorderColor= (Color)Application.Current.Resources["Secondary"],
                BorderWidth= 2,
                CornerRadius= 15,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 10, 0, 0)
            };
            startButton.Clicked += (sender, e) =>
            {
                StartTimer(timer, startButton);
            };

            var stackLayout = new StackLayout
            {
                Children = { nameLabel, timeLabel, startButton }
            };

            frame.Content = stackLayout;

            return frame;
        }

        private void StartTimer(TimerModel timer, Button startButton)
        {
            if (timer.OriginalDuration.TotalMinutes == timer.RemainingTime.TotalMinutes) {
                timer.TimerInstance = new System.Timers.Timer(1000);
                ((System.Timers.Timer)timer.TimerInstance).Elapsed += (sender, e) =>
                {
                    if (timer.RemainingTime > TimeSpan.Zero)
                    {
                        timer.RemainingTime = timer.RemainingTime.Subtract(TimeSpan.FromSeconds(1));
                    }
                    else
                    {
                        ((System.Timers.Timer)timer.TimerInstance).Stop();
                    }
                };
                ((System.Timers.Timer)timer.TimerInstance).Start();
            }
        }

        private void PauseTimer(TimerModel timer)
        {
            ((System.Timers.Timer)timer.TimerInstance)?.Stop();
        }

        private void StartAllTimers(object sender, EventArgs e)
        {
            foreach (var timer in viewModel.ActiveTimers)
            {
                    var frame = CreateTimerFrame(timer);
                    StartTimer(timer, startButton);
            }
        }

        private string TimerCount(object sender, EventArgs e)
        {
            int index = 0;
            foreach (var timer in viewModel.ActiveTimers)
            {
                index++;
            }

            string returnMessage = "Timer Count: " + index.ToString();
            return returnMessage;
        }

        private async void NavToTimerCreation(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TimerCreate));
        }
    }
}