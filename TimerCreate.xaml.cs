namespace maui_capstone
{
    public partial class TimerCreate : ContentPage
    {
        private TimersViewModel viewModel;

        public TimerCreate()
        {
            InitializeComponent();
            viewModel = new TimersViewModel();
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

        private void OnAddTimerClicked(object sender, EventArgs e)
        {
            string timerName = "New Timer"; // You can replace this with a user input
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
}
