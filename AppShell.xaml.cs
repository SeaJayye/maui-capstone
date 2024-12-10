namespace maui_capstone
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void NavToTimerCreation(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TimerCreate));
        }

    }
}
