using Diary.Models;
using Diary.ViewModels;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MenuPage : ContentPage
	{
		MainPage RootPage { get => Application.Current.MainPage as MainPage; }
		List<HomeMenuItem> menuItems;

		private readonly RealmDbViewModel realmDb;
		public MenuPage()
		{
			InitializeComponent();

			realmDb = DependencyService.Get<RealmDbViewModel>();

			menuItems = new List<HomeMenuItem>
			{
				new HomeMenuItem {Id = MenuItemType.Account.ToString(), Title="Account" },
				//new HomeMenuItem {Id = MenuItemType.Tasks, Title="Tasks" },
				new HomeMenuItem {Id = MenuItemType.About.ToString(), Title="About" }
			};

			var realm = realmDb.GetDbInstance();
			//AddSample(realm);

			//realm.Write(() =>
			//{
			//	var newList = new TaskListEntity()
			//	{
			//		Name = "Лист заданий"
			//	};
			//	realm.Add(newList);
			//});

			var lists = realm.All<TaskListEntity>().ToList();
			foreach (TaskListEntity list in lists)
				menuItems.Add(new HomeMenuItem { Id = list.Name, Title = list.Name });

			ListViewMenu.ItemsSource = menuItems;

			ListViewMenu.SelectedItem = menuItems[0];
			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;

				var id = ((HomeMenuItem)e.SelectedItem).Id;
				await RootPage.NavigateFromMenu(id);
			};

		}

		//private void AddSample(Realm realm)
		//{
		//	var list = new TaskList("Today");

		//	list.Add(new OuterTask
		//	{
		//		Header = "quwuwu",
		//		Note = "123",
		//		Priority = Priority.Low,
		//	});

		//	var outItem = new OuterTask
		//	{
		//		Header = "СПАТЬ",
		//	};

		//	outItem.Add(
		//		new TodoModel.Task()
		//		{
		//			Header = "Мыть попу",
		//			Note = "С мылом",
		//		}
		//		);

		//	outItem.Add(
		//		new TodoModel.Task()
		//		{
		//			Header = "Чистить зубы",
		//			Note = "Не с мылом",
		//		});

		//	list.Add(outItem);

		//	list.Add(new OuterTask
		//	{
		//		Header = "WALK",
		//		Note = "With dog",
		//		Priority = Priority.Hight,
		//	});
		//}

		private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}