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

		private readonly RealmDbViewModel realmDb;
		private readonly MenuViewModel menuViewModel;

		public MenuPage()
		{
			InitializeComponent();

			menuViewModel = DependencyService.Get<MenuViewModel>();
			realmDb = DependencyService.Get<RealmDbViewModel>();

			var realm = realmDb.GetDbInstance();
			#region Лист заданий
			//AddSample(realm);

			//realm.Write(() =>
			//{
			//	var newList = new TaskListEntity()
			//	{
			//		Name = "Лист заданий"
			//	};
			//	realm.Add(newList);
			//});
			#endregion

			var lists = realm.All<TaskListEntity>().ToList().Select(x => new HomeMenuItem() { Id = x.Name, Title = x.Name });
			menuViewModel.Add(lists);

			ListViewMenu.ItemsSource = menuViewModel.GetInstance();

			ListViewMenu.SelectedItem = menuViewModel.GetInstance()[0];

			menuViewModel.Add(new HomeMenuItem { Id = MenuItemType.About.ToString(), Title = "About" });

			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;

				var id = ((HomeMenuItem)e.SelectedItem).Id;
				await RootPage.NavigateFromMenu(id);
			};
		}

		#region AddSample
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
		#endregion

		private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}