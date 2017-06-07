using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturePadWizardDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuccessPage : ContentPage
	{
		public SuccessPage()
		{
			InitializeComponent();

			BindingContext = this;
		}

		public PersonalDetailsModel PersonalDetails => App.Current.PersonalDetails;

		public string FullName => $"{PersonalDetails.FirstName} {PersonalDetails.LastName}".Trim();

		private void OnRestartClicked(object sender, EventArgs e)
		{
			App.Current.RestartWizard();
		}
	}
}
