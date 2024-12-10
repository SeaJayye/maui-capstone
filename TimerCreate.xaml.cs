using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace maui_capstone
{

    public partial class TimerCreate : ContentPage
    {
        private TimersViewModel viewModel;

        public TimerCreate()
        {
            InitializeComponent();
            viewModel = ((App)Application.Current).TimersViewModel;
            BindingContext = viewModel;
        }

        private void OnIncreaseTimeClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var timer = button.BindingContext as TimerModel;
            viewModel.IncreaseTime(timer, TimeSpan.FromMinutes(1));
        }

        private void OnDecreaseTimeClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var timer = button.BindingContext as TimerModel;
            viewModel.DecreaseTime(timer, TimeSpan.FromMinutes(1));
        }

        GlobalIndex count = new GlobalIndex();
        private void OnAddTimerClicked(object sender, EventArgs e)
        {
            count.incr();
            string timerName = "Timer " + (count.count).ToString(); // You can replace this with a user input
            TimeSpan initialTime = TimeSpan.FromMinutes(10); // You can replace this with a user input
            viewModel.AddTimer(timerName, initialTime);
        }

        private async void OnUpdateTimerNameClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var timer = button.BindingContext as TimerModel;
            string newName = await DisplayPromptAsync("Update Timer Name", "Enter new timer name:");
            if (!string.IsNullOrEmpty(newName))
            {
                viewModel.UpdateTimerName(timer, newName);
            }
        }
    }

    public class GlobalIndex
    {
        public GlobalIndex() { count = 0; }
        public int count {  get; set; }

        public void incr()
        {
            count++;
        }

    }
}
