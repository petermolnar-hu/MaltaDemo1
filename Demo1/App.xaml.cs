using Xamarin.Forms;

namespace Demo1
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Demo1Page());

			DependencyService.Register<IBooksRepository, BooksRepository>();
			DependencyService.Register<IAlertService, AlertService>();
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
