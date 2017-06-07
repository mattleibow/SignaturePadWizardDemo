using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace SignaturePadWizardDemo
{
	public class PersonalDetailsModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FavouriteIde { get; set; }

		public bool LikeXamarinForms { get; set; }

		public bool LikeSignaturePad { get; set; }

		public List<Point> SignaturePoints { get; set; }

		public Stream SignatureImage { get; set; }
	}
}
