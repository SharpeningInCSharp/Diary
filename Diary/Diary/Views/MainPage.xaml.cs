using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Diary.Models;
using Realms;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : MasterDetailPage
	{
		Dictionary<string, NavigationPage> MenuPages = new Dictionary<string, NavigationPage>();
		public MainPage()
		{

			TodoModel.Database.SettingsInitialization.ParamsSetting(); //инициализация параметров в Realm

			InitializeComponent();

			MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add(MenuItemType.Tasks.ToString(), (NavigationPage)Detail);
            NavigateFromMenu("Account");

		}

		public async Task NavigateFromMenu(string id)
		{
			if (!MenuPages.ContainsKey(id))
			{
				switch (id)
				{
					case "Account":
						MenuPages.Add(id, new NavigationPage(new AccountPage()));
						break;

					case "About":
						MenuPages.Add(id, new NavigationPage(new AboutPage()));
						break;

					default:
						MenuPages.Add(id, new NavigationPage(new ItemsPage(id)));
						//MenuPages.Add(id, new NavigationPage(new ItemsPage()));
						break;
				}
			}

			var newPage = MenuPages[id];

			if (newPage != null && Detail != newPage)
			{
				Detail = newPage;

				//if (Device.RuntimePlatform == Device.Android)
				//	await Task.Delay(100);

				IsPresented = false;
			}
		}
	}
}