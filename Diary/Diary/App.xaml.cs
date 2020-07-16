using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Diary.Services;
using Diary.Views;

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
