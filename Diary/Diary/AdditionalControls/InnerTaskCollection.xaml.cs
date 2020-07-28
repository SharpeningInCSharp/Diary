﻿using System;
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
	public partial class InnerTaskCollection : ContentView
	{
		private const int OnTaskCompletionMsTimeout = 350;
		private const int SingleCollectionItemSize = 75;

		public InnerTaskCollection()
		{
			InitializeComponent();
		}

		private async void OnItemCompleted(object sender, EventArgs e)
		{
			var layout = (Grid)sender;

			var image = (Image)layout.Children[1];
			image.Source = "tick_icon.png";

			layout.TranslateTo(Application.Current.MainPage.Width, 0, 350, Easing.CubicIn);

			var item = (TaskBase)layout.BindingContext;
			await System.Threading.Tasks.Task.Run(() => OnTaskCompletion(item));
		}

		/// <summary>
		/// Task completion animation
		/// </summary>
		/// <param name="item"></param>
		private void OnTaskCompletion(TaskBase item)
		{
			Thread.Sleep(OnTaskCompletionMsTimeout);

			item.Complete();
		}

		private async void OnItemSelected(object sender, EventArgs e)
		{
			var layout = (BindableObject)sender;
			var item = (TaskBase)layout.BindingContext;

			await Navigation.PushAsync(new TaskDetailsView(item), false);
		}

		private void InnerColl_BindingContextChanged(object sender, EventArgs e)
		{
			if (BindingContext is IEnumerable<TaskBase> taskCollection)
			{
				InnerTasksCollectionView.ItemsSource = taskCollection;
				InnerTasksCollectionView.HeightRequest = taskCollection.Count() * SingleCollectionItemSize;
			}
			else
			{
				InnerTasksCollectionView.HeightRequest = 0;
			}
		}
	}
}