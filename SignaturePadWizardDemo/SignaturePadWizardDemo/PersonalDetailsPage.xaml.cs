using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturePadWizardDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalDetailsPage : ContentPage
	{
		public PersonalDetailsPage()
		{
			InitializeComponent();

			BindingContext = this;
		}

		public PersonalDetailsModel PersonalDetails => App.Current.PersonalDetails;

		private void OnBackClicked(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		private void OnNextClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SignaturePage());
		}
	}
}
