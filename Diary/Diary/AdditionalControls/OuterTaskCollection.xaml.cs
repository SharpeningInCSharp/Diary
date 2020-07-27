using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OuterTaskCollection : ContentView
	{
		public OuterTaskCollection()
		{
			InitializeComponent();

			//BindingContext = this;

			//TODO: bind events
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{

		}
	}
}