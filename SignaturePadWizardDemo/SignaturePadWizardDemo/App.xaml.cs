using Xamarin.Forms;

namespace SignaturePadWizardDemo
{
	public partial class App : Application
	{
		private PersonalDetailsModel personalDetails;

		public App()
		{
			personalDetails = new PersonalDetailsModel();

			InitializeComponent();

			RestartWizard();
		}

		public PersonalDetailsModel PersonalDetails => personalDetails;

		public static new App Current => ((App)Application.Current);

		public void RestartWizard()
		{
			MainPage = new NavigationPage(new MainPage());
		}

		public void CompleteWizard()
		{
			MainPage = new NavigationPage(new SuccessPage());
		}
	}
}
