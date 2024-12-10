namespace maui_capstone
{
    public partial class App : Application
    {
        public TimersViewModel TimersViewModel { get; private set; } // Added TimersViewModel property

        public App()
        {
            InitializeComponent();
            TimersViewModel = new TimersViewModel(); // Initialize TimersViewModel
            MainPage = new AppShell();
        }
    }
}
