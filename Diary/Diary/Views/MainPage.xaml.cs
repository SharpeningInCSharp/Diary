using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            NavigateFromMenu("About");
		}

		public async Task NavigateFromMenu(string id)
		{
			if (!MenuPages.ContainsKey(id))
			{
				switch (id)
				{
					case "About":
						MenuPages.Add(id, new NavigationPage(new AboutPage()));
						break;

					default:
						MenuPages.Add(id, new NavigationPage(new ItemsPage(id)));
						break;
				}
			}

			var newPage = MenuPages[id];

			if (newPage != null && Detail != newPage)
			{
				Detail = newPage;
				IsPresented = false;
			}
		}
	}
}