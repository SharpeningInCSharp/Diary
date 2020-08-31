﻿using System;
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
			#region Realm com
			/// временное, пример записи в бд // я допишу не трогайте :)))))
			//var realm = Realm.GetInstance();
			//realm.Write(() =>
			//{
			//realm.Remove(realm.All<PriorityEntity>().First(x => x.Name == "NuTakSebe"));
			//realm.Remove(realm.All<PriorityEntity>().First(x => x.Name == "Normas"));

			//    System.Drawing.Color a = new System.Drawing.Color();
			//    a = System.Drawing.Color.Chartreuse;
			//    var newNote = new PriorityEntity
			//    {
			//        Name = "Low",
			//        Value = 2,
			//        Color = a.ToArgb()

			//    };
			//    realm.Add(newNote);
			//    a = System.Drawing.Color.Gold;
			//    var alsonewNote = new PriorityEntity
			//    {
			//        Name = "Normal",
			//        Value = 5,
			//        Color = a.ToArgb()

			//    };
			//    realm.Add(alsonewNote);
			//    a = System.Drawing.Color.Red;
			//    var alsoalsonewNote = new PriorityEntity
			//    {
			//        Name = "Hight",
			//        Value = 8,
			//        Color = a.ToArgb()

			//    };
			//    realm.Add(alsoalsonewNote);
			//});
			#endregion

			//TODO: воложить обязаности работы с БД на контроллер. В специальный метод GetInstance, который возвращает объект реалма нужной версии
			//var l = taskItemsViewModel.GetDbInstance().All<TaskListEntity>().Single(x => x.Name == listId);

			var realm = taskItemsViewModel.GetDbInstance();
			var l = realm.All<TaskListEntity>().Single(x => x.Name == listId);

			#region Sample items
			//TasksList = new TaskList("Today");
			//;

			//TasksList.Add(new OuterTask
			//{
			//	Header = "quwuwu",
			//	Note = "123",
			//	Priority = Priority.Low,
			//});

			//var outItem = new OuterTask
			//{
			//	Header = "СПАТЬ",
			//};

			//outItem.Add(
			//	new TodoModel.Task()
			//	{
			//		Header = "Мыть попу",
			//		Note = "С мылом",
			//	}
			//	);

			//outItem.Add(
			//	new TodoModel.Task()
			//	{
			//		Header = "Чистить зубы",
			//		Note = "Не с мылом",
			//	});

			//TasksList.Add(outItem);

			//TasksList.Add(new OuterTask
			//{
			//	Header = "WALK",
			//	Note = "With dog",
			//	Priority = Priority.Hight,
			//});
			#endregion

			TasksList = new TaskList(l);
			TasksList.CollectionChanged += TasksList_CollectionChanged;
			BindingContext = TasksList;
		}

		private async void TasksList_CollectionChanged()
		{
			Dispatcher.BeginInvokeOnMainThread(() =>
			{
				TasksCollection.BindingContext = null;
				TasksCollection.BindingContext = TasksList;
			});

			//await System.Threading.Tasks.Task.Run(() =>);		//save changes in db
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			if (TasksList is null)
			{
				var inputName = await InputListName();

				await AddNewList(inputName);

				return;
			}

			var empltyTask = new OuterTask();
			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);

			await Navigation.PushAsync(new TaskDetailsView(empltyTask, TasksList), false);

			TasksList.Add(empltyTask);

			AddButton.Rotation = 0;
		}

		private async System.Threading.Tasks.Task AddNewList(string inputName)
		{
			TasksList = new TaskList(inputName);

			var db = taskItemsViewModel.GetDbInstance();
			db.Write(() =>
			{
				db.Add(new TaskListEntity(TasksList));
			});

			await DisplayPromptAsync("Message", "New list successfuly created");
		}

		private async Task<string> InputListName()
		{
			string input = "";

			while (DataValidation.IsNameValid(input) == false)
			{
				input = await DisplayPromptAsync("Enter Task's list name", "There're no lists available, please create new");
			}

			return input;
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
	}
}