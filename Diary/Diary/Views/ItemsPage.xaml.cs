using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
using Xamarin.Forms.Internals;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		TaskList TasksList;
		private readonly TaskItemsViewModel taskItemsViewModel;
		private readonly MenuViewModel menuViewModel;

		public ItemsPage()
		{
			taskItemsViewModel = DependencyService.Get<TaskItemsViewModel>();
			menuViewModel = DependencyService.Get<MenuViewModel>();

			InitializeComponent();
		}

		public ItemsPage(string listId) : this()
		{


			var realm = taskItemsViewModel.GetDbInstance();
			var l = realm.All<TaskListEntity>().Single(x => x.Name == listId);
			
			TasksList = new TaskList(l);
			OuterTaskCollection.TaskList = TasksList;

			TasksList.CollectionChanged += TasksList_CollectionChanged;
			BindingContext = TasksList;
			TasksList_CollectionChanged();
		}

		private async void TasksList_CollectionChanged()
		{
			Dispatcher.BeginInvokeOnMainThread(() =>
			{
				TasksCollection.BindingContext = null;
				TasksCollection.BindingContext = TasksList;
			});
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			//if (TasksList is null)
			//{
			//	var inputName = await InputListName();

			//	await AddNewList(inputName);

			//	return;
			//}

			var empltyTask = new OuterTask();
			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);

			await Navigation.PushAsync(new TaskDetailsView(empltyTask, TasksList), false);

			TasksList.Add(empltyTask);

			var db = taskItemsViewModel.GetDbInstance();
            db.Write(() =>
            {
                TodoNote newNote = new TodoNote();
                Settings newSet = new Settings()
                {
                    Param = "Notes",
                    value = db.All<Settings>().First(x => x.Param == "Notes").value + 1
                };
                db.Add(newSet, update: true);
                newNote.Id = db.All<Settings>().First(x => x.Param == "Notes").value;
                newNote.HasInners = false;
                newNote.header = " ";
                newNote.Note = " ";
                newNote.IsCompleted = false;
                newNote.taskList = db.All<TaskListEntity>().First(x => x.Name == TasksList.Title);
                db.Add(newNote);
            });

            AddButton.Rotation = 0;
		}

		//private async System.Threading.Tasks.Task AddNewList(string inputName)
		//{
		//	TasksList = new TaskList(inputName);

		//	var db = taskItemsViewModel.GetDbInstance();
		//	db.Write(() =>
		//	{
		//		db.Add(new TaskListEntity(TasksList));
		//	});

		//	await DisplayPromptAsync("Message", "New list successfuly created");
		//}

		//private async Task<string> InputListName()
		//{
		//	string input = "";

		//	while (DataValidation.IsNameValid(input) == false)
		//	{
		//		input = await DisplayPromptAsync("Enter Task's list name", "There're no lists available, please create new");
		//	}

		//	return input;
		//}

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
	}
}