namespace maui_capstone
{
    public partial class App : Application
    {
        public TimersViewModel TimersViewModel { get; private set; }

        public App()
        {
            InitializeComponent();
            TimersViewModel = new TimersViewModel(); // init new viewmodel
            MainPage = new AppShell();

        }
    }
}
