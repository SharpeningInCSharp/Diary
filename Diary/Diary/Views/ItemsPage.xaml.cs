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
using Xamarin.Forms.Shapes;

namespace Diary.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemsPage : ContentPage
	{
		TaskList TasksList;
		///System.InvalidOperationException: 
		///'The class, property, or method you are attempting to use ('.ctor') is part of Shape;
		///to use it, you must opt-in by calling Forms.SetFlags("Shapes_Experimental") before calling Forms.Init().'

		public ItemsPage()
		{
			InitializeComponent();

			TasksList = new TaskList("Today");

			//TasksList.CollectionChanged += TasksList_CollectionChanged;

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
				Note = "With dog",
			});

			BindingContext = TasksList;

			OnInitialization();
		}

		private void OnInitialization()
		{
			//var e = new Ellipse();
			//e.WidthRequest = 29;
			//e.HeightRequest = 23;
		}

		private void TasksList_CollectionChanged()
		{
			BindingContext = null;
			BindingContext = TasksList;
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (TaskBase)layout.BindingContext;

			await Navigation.PushAsync(new TaskDatailsView(item));
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			var empltyTask = new TodoModel.Task();

			TasksList.Add(empltyTask);

			await AddButton.RotateTo(-135, 200, Easing.CubicInOut);
			await Navigation.PushAsync(new TaskDatailsView(empltyTask));
			AddButton.Rotation = 0;
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void SearchDate_Clicked(object sender, EventArgs e)
		{
			
		}

		private void Ordering_Click(object seder, EventArgs e)
		{
			if (TasksList.Ascending)
			{
				SortBut.IconImageSource = "sort_accending_icon.png";
			}
			else
			{
				SortBut.IconImageSource = "sort_descending_icon.png";
			}

			TasksList.OrderByPriority();

		}
	}
}