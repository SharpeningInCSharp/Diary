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
using Diary.AdditionalControls;

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

			BindingContextChanged += ItemsPage_BindingContextChanged;

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

		private void ItemsPage_BindingContextChanged(object sender, EventArgs e)
		{
			var i = 1932;
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (TaskBase)layout.BindingContext;

			await Navigation.PushAsync(new TaskDatailsView(item));
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new TaskDatailsView());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (TasksList != null)
			{
				BindingContext = null;
				BindingContext = TasksList;
			}

			UpdateChildrenLayout();
			//if (viewModel.Items.Count == 0)
			//	viewModel.IsBusy = true;
		}

		private void SearchDate_Clicked(object sender, EventArgs e)
		{

		}

		private void Ordering_Click(object seder, EventArgs e)
		{

		}
	}
}