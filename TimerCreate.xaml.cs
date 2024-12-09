using maui_capstone.ViewModels;

namespace maui_capstone
{
    public partial class TimerCreate : ContentPage
    {
        public TimerCreate()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
