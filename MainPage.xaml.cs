using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

namespace maui_capstone
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TimerCreate), typeof(TimerCreate));
            
        }

        private async void NavToTimerCreation(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TimerCreate));
        }
        
    } 

}