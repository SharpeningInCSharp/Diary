using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Diary.Models;
using Diary.Views;
using Diary.ViewModels;

using TodoModel;
using TodoModel.Database;
using Diary.AdditionalControls;
using Xamarin.Forms.Shapes;
using System.Threading;
using Realms;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		private const int OnTaskCompletionMsTimeout = 350;

		TaskList TasksList;

		public ItemsPage()
		{
			InitializeComponent();

            /// временное, пример записи в бд // я допишу не трогайте :)))))
			//  var realm = Realm.GetInstance();
			//realm.Write(() =>
			//{
			//	Color a = new Color();
			//	a = Color.Crimson;
			//  var newNote = new PriorityEntity
			//  {
			//   Name = "GlavniyPriotitet",
			//   Value = 10,
			//	Color = a.,

			//  };
			//   realm.Add(newNote);
			//  });
            ///

            TasksList = new TaskList("Today");
			TasksList.CollectionChanged += TasksList_CollectionChanged;



			TasksList.Add(new TodoModel.Task
			{
				Header = "Мыть попу",
				Note = "с мылом",
			});

			TasksList.Add(new TodoModel.Task
			{
				Header = "RUN",
			});

			TasksList.Add(new TodoModel.Task
			{
				Header = "WALK",
				Note = "With dog",
			});

			BindingContext = TasksList;
		}

		private void TasksList_CollectionChanged()
		{
			Dispatcher.BeginInvokeOnMainThread(() =>
			{
				BindingContext = null;
				BindingContext = TasksList;
			});
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (TaskBase)layout.BindingContext;

			await Navigation.PushAsync(new TaskDatailsView(item), false);
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			var empltyTask = new TodoModel.Task();			

			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);
			await Navigation.PushAsync(new TaskDatailsView(empltyTask), false);

			TasksList.Add(empltyTask);

			AddButton.Rotation = 0;
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void SearchDate_Clicked(object sender, EventArgs e)
		{

		}

		private void Ordering_Click(object seder, EventArgs e)
		{
			if (TasksList.Ascending)
			{
				SortBut.IconImageSource = "sort_accending_icon.png";
			}
			else
			{
				SortBut.IconImageSource = "sort_descending_icon.png";
			}

			TasksList.OrderByPriority();
		}

		private async void OnItemCompleted(object sender, EventArgs e)
		{
			var layout = (Grid)sender;

			var image = (Image)layout.Children[1];
			image.Source = "tick_icon.png";

			layout.TranslateTo(Application.Current.MainPage.Width, 0, 350, Easing.CubicIn);
			
			var item = (TaskBase)layout.BindingContext;
			//item.Complete();
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
	}
}