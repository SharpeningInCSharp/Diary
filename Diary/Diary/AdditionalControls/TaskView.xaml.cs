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
	public partial class TaskView : ContentView
	{
		public TaskView()
		{
			InitializeComponent();
		}

		private void RemoveButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}