using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Diary.ViewModels;
using TodoModel;
using TodoModel.Database;
using Diary.AdditionalControls;

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
			var empltyTask = new OuterTask();
			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);
			TaskDetailsView qwerty = new TaskDetailsView(empltyTask, TasksList, true);
            qwerty.list_changed += Qwerty_list_changed; ;
			await Navigation.PushAsync(qwerty, false);


            AddButton.Rotation = 0;
		}

        private void Qwerty_list_changed(TodoModel.Task a)
        {
			TasksList.Add(a);
			TasksList_CollectionChanged();
		}


        protected override void OnAppearing()
		{
			base.OnAppearing();
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