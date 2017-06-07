using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturePadWizardDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmPage : ContentPage
	{
		public ConfirmPage()
		{
			InitializeComponent();

			BindingContext = this;
		}

		public PersonalDetailsModel PersonalDetails => App.Current.PersonalDetails;

		public ImageSource SignatureImage => ImageSource.FromStream(() => PersonalDetails.SignatureImage);

		public string SignatureSize
		{
			get
			{
				var size = PersonalDetails.SignatureImage.Length / 1024f;
				var points = PersonalDetails.SignaturePoints.Count;
				return $"{size:0.00} KB with {points} points.";
			}
		}

		private void OnBackClicked(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		private void OnNextClicked(object sender, EventArgs e)
		{
			App.Current.CompleteWizard();
		}
	}
}
