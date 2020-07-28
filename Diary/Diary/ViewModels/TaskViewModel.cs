using Diary.AdditionalControls;
using System;
using System.Diagnostics;
using System.Threading;
using TodoModel;
using Xamarin.Forms;

namespace Diary.ViewModels
{
	/// <summary>
	/// Provides general UI for <see cref="TaskBase"/> completion and details managment
	/// </summary>
	internal class TaskViewModel
	{
		private const int OnTaskCompletionMsTimeout = 350;

		/// <summary>
		/// Provides required animation and action to Complete <see cref="TaskBase"/> in <paramref name="layout"/>.BindingContext 
		/// </summary>
		/// <param name="layout">Grid with <see cref="TaskBase"/> in BindingContext prop</param>
		public async void ItemCompleted(Layout<View> layout)
		{
			try
			{
				var image = (Image)layout.Children[1];
				image.Source = "tick_icon.png";

				await System.Threading.Tasks.Task.Run(() => OnTaskCompletion(layout));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private void OnTaskCompletion(Layout<View> layout)
		{
			layout.TranslateTo(Application.Current.MainPage.Width, 0, 350, Easing.CubicIn);

			Thread.Sleep(OnTaskCompletionMsTimeout);

			var item = (TaskBase)layout.BindingContext;
			item.Complete();
		}

		/// <summary>
		/// Provides required actions to Select <see cref="TaskBase"/> in <paramref name="layout"/>.BindingContext
		/// and move to <see cref="TaskDetailsView"/> page
		/// </summary>
		/// <param name="navigation">Abstraction to navigate to a <see cref="TaskDetailsView"/> page</param>
		/// <param name="layout">An object with <see cref="TaskBase"/> in BindingContext</param>
		public async void ItemSelected(INavigation navigation, BindableObject layout)
		{
			try
			{
				var item = (TaskBase)layout.BindingContext;
				await navigation.PushAsync(new TaskDetailsView(item), false);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

		}
	}
}
