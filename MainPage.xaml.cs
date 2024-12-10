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
        }

        private void ActiveTimers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var newItem in e.NewItems)
            {
                var timer = newItem as TimerModel;
                var frame = CreateTimerFrame(timer);
                TimerContainer.Children.Add(frame); // Add new frame to TimerContainer
            }
        }

        private Frame CreateTimerFrame(TimerModel timer)
        {
            var label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 18,
                TextColor = (Color)Application.Current.Resources["SecondaryLight"]
            };
            label.SetBinding(Label.TextProperty, new Binding("TimerName", source: timer));

            return new Frame
            {
                BackgroundColor = (Color)Application.Current.Resources["Primary"],
                HasShadow = true,
                CornerRadius = 25,
                Margin = new Thickness(20),
                HeightRequest = 230,
                WidthRequest = 140,
                BorderColor = (Color)Application.Current.Resources["SecondaryLight"],
                HorizontalOptions = LayoutOptions.Center,
                Content = label
            };
        }

        private async void NavToTimerCreation(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TimerCreate));
        }
    }
}