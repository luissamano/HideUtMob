using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace HideUtMob
{
	public partial class App : Application
	{

		
		public App()
		{
			InitializeComponent();
			MainPage = new HideUtMobPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts

			MobileCenter.Start("ios=4148df30-c71b-470a-9f71-7a45a30c7498;" +
				               "uwp={Your UWP App secret here};" +
				               "android={Your Android App secret here}",
				               typeof(Analytics), typeof(Crashes));
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
