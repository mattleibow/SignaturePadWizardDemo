using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignaturePadWizardDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignaturePage : ContentPage
	{
		public SignaturePage()
		{
			InitializeComponent();

			BindingContext = this;
		}

		public PersonalDetailsModel PersonalDetails => App.Current.PersonalDetails;

		protected override void OnAppearing()
		{
			base.OnAppearing();

			RestoreSignature();
		}

		private void OnBackClicked(object sender, EventArgs e)
		{
			// don't save picture on back
			SaveSignatureAsync(false);

			Navigation.PopAsync();
		}

		private async void OnNextClicked(object sender, EventArgs e)
		{
			if (signaturePad.IsBlank)
			{
				DisplayAlert("No Signature", "No signature was drawn. Please make sure that you sign above the line.", "OK");
				return;
			}

			// save all on next
			await SaveSignatureAsync(true);

			await Navigation.PushAsync(new ConfirmPage());
		}

		private void RestoreSignature()
		{
			var pd = App.Current.PersonalDetails;

			// just to make sure
			signaturePad.Clear();

			// load the saved signature
			if (pd.SignaturePoints != null)
			{
				signaturePad.Points = pd.SignaturePoints;
			}
		}

		private async Task SaveSignatureAsync(bool saveImage)
		{
			IsBusy = true;

			var pd = App.Current.PersonalDetails;

			// save the signature points
			pd.SignaturePoints = signaturePad.Points.ToList();

			if (saveImage)
			{
				// save the signature image (encoded as .png)
				pd.SignatureImage = await signaturePad.GetImageStreamAsync(SignatureImageFormat.Png, new ImageConstructionSettings
				{
					BackgroundColor = Color.Transparent,
					ShouldCrop = true,
					StrokeColor = Color.Black,
					StrokeWidth = 2,
				});
			}

			IsBusy = false;
		}
	}
}
