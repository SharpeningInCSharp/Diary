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
		public ItemsPage()
		{
			taskItemsViewModel = DependencyService.Get<TaskItemsViewModel>();

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

			var config = new RealmConfiguration() { SchemaVersion = 3 };
			var realm = Realm.GetInstance(config);
			var l = realm.All<TaskListEntity>().Single(x => x.Name == listId);
			//#region Sample items
			//TasksList = new TaskList("Today");
			//TasksList.CollectionChanged += TasksList_CollectionChanged;

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
			//#endregion

			//BindingContext = TasksList;
			BindingContext = l;
		}

		private void TasksList_CollectionChanged()
		{
			Dispatcher.BeginInvokeOnMainThread(() =>
			{
				TasksCollection.BindingContext = null;
				TasksCollection.BindingContext = TasksList;
			});
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			var empltyTask = new OuterTask();
			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);

			await Navigation.PushAsync(new TaskDetailsView(empltyTask), false);

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
	}
}