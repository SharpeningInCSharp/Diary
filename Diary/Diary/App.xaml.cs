using Xamarin.Forms;
using Diary.Services;
using Diary.Views;
using Diary.ViewModels;

namespace Diary
{
    public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MenuViewModel>();
			DependencyService.Register<MockDataStore>();
			DependencyService.Register<TaskViewModel>();
			DependencyService.Register<TaskItemsViewModel>();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{

		}

		protected override void OnResume()
		{
		}
	}
}
