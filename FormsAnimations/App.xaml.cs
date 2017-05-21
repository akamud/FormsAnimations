using Xamarin.Forms;

namespace FormsAnimations
{
    public partial class App : Application
    {
        public static bool IsAnimated = false;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FormsAnimationsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

