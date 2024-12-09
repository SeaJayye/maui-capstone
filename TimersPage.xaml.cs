using maui_capstone.ViewModels;

namespace maui_capstone
{
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private async void OnCreateTimerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerCreate());
        }
    }
}