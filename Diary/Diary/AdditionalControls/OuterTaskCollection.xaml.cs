using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OuterTaskCollection : ContentView
	{
		private const int OnTaskCompletionMsTimeout = 350;

		public OuterTaskCollection()
		{
			InitializeComponent();

			//TODO: bind events
			//TODO: extract some actions (OnItemCompleted, OnTaskCompleted) to separated Controller
		}

		private async void OnItemCompleted(object sender, EventArgs e)
		{
			var layout = (Grid)sender;

			var image = (Image)layout.Children[1];
			image.Source = "tick_icon.png";

			await System.Threading.Tasks.Task.Run(() => OnTaskCompletion(layout));
		}

		/// <summary>
		/// Task completion animation
		/// </summary>
		/// <param name="item"></param>
		private void OnTaskCompletion(Grid layout)
		{
			layout.TranslateTo(Application.Current.MainPage.Width, 0, 350, Easing.CubicIn);

			Thread.Sleep(OnTaskCompletionMsTimeout);

			var item = (TaskBase)layout.BindingContext;
			item.Complete();
		}

		private async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (TaskBase)layout.BindingContext;

			await Navigation.PushAsync(new TaskDetailsView(item), false);
		}
	}
}