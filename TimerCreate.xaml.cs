namespace maui_capstone
{
    public partial class TimerCreate : ContentPage
    {
        private TimersViewModel viewModel; // Added viewModel field

        public TimerCreate()
        {
            InitializeComponent();
            viewModel = ((App)Application.Current).TimersViewModel; // Updated to use shared TimersViewModel instance
            BindingContext = viewModel; // Set BindingContext to viewModel
        }

        // Method to increase the remaining time of a timer by 1 minute
        private void OnIncreaseTimeClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var timer = button.BindingContext as TimerModel;
            viewModel.IncreaseTime(timer, TimeSpan.FromMinutes(1));
        }

        // Method to decrease the remaining time of a timer by 1 minute
        private void OnDecreaseTimeClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var timer = button.BindingContext as TimerModel;
            viewModel.DecreaseTime(timer, TimeSpan.FromMinutes(1));
        }

        // Method to add a new timer with a default name and initial time
        private void OnAddTimerClicked(object sender, EventArgs e)
        {
            string timerName = "New Timer"; // You can replace this with a user input
            TimeSpan initialTime = TimeSpan.FromMinutes(10); // You can replace this with a user input
            viewModel.AddTimer(timerName, initialTime);
        }

        // Method to update the name of a timer with user input
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
