using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Diary.Models;
using Diary.Views;
using Diary.ViewModels;

using TodoModel;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		TaskList TasksList;

		public ItemsPage()
		{
			InitializeComponent();

			TasksList = new TaskList("Today");

			TasksList.Add(new TodoModel.Task
			{
				Header = "Мыть попу",
				Note = "с мылом",
			});

			TasksList.Add(new TodoModel.Task
			{
				Header = "RUN",
			});

			TasksList.Add(new TodoModel.Task
			{
				Header = "WALK",
				Note = "Alone",
			});

			BindingContext = TasksList;
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (Item)layout.BindingContext;
			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//if (viewModel.Items.Count == 0)
			//	viewModel.IsBusy = true;
		}
	}
}