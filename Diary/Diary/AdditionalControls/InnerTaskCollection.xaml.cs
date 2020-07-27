using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InnerTaskCollection : ContentView
	{
		public InnerTaskCollection()
		{
			InitializeComponent();
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{

		}

		private void OnItemSelected(object sender, EventArgs e)
		{

		}
	}
}