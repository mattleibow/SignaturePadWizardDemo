using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturePadWizardDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnNextClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PersonalDetailsPage());
		}
	}
}
