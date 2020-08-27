using Diary.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
		public MenuPage()
		{
			InitializeComponent();

            ///TODO: взять из БД все названия списков и их Id и добавить в список menuItems
            ///раскомментить кусок в default в MainPage.cs
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Account.ToString(), Title="Account" },
				//new HomeMenuItem {Id = MenuItemType.Tasks, Title="Tasks" },
				new HomeMenuItem {Id = MenuItemType.About.ToString(), Title="About" }
            };

			var config = new RealmConfiguration() { SchemaVersion = 3 };
			var realm = Realm.GetInstance(config);

			//realm.Write(() => //пример добавления нового списка в бд
			//{
			//	var newSet = new TaskListEntity
			//	{
			//		Name = "Daily Tasks"
			//	};
			//	realm.Add(newSet);
			//});

			var lists = realm.All<TaskListEntity>().ToList();
			foreach (TaskListEntity list in lists)
				menuItems.Add(new HomeMenuItem {Id = list.Name, Title = list.Name});

			ListViewMenu.ItemsSource = menuItems;
			
			ListViewMenu.SelectedItem = menuItems[1];
			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;

				var id = ((HomeMenuItem)e.SelectedItem).Id;
				await RootPage.NavigateFromMenu(id);
			};
		}

		private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}