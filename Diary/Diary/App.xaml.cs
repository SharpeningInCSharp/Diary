using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

			///TODO: здесь добавить в DependencyService класс, имплементирующий <see cref="TodoModel.Database.ITodoStorage"/>
			///it automatically calls new() 
			DependencyService.Register<MockDataStore>();
			DependencyService.Register<TaskViewModel>();
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
			//TODO: save changes in db here
		}

		protected override void OnResume()
		{
		}
	}
}
