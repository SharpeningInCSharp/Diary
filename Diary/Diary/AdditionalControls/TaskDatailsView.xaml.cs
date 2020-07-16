using System;
using System.Collections.Generic;
using System.Linq;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDatailsView : ContentPage
	{
		public TaskBase Task { get; }

		//TOOD: should pick out ViewModel with access to DB
		private ITodoStorage storage;
		public TaskDatailsView(TaskBase task)
		{
			InitializeComponent();

			PriorityPicker.ItemsSource = new List<IPriority>
			{ Priority.Low, Priority.Hight, Priority.Normal};

			BindingContext = Task = task ?? throw new ArgumentNullException(nameof(task));
			//storage = DependencyService.Get<ITodoStorage>();
			//InitializeCB();
		}

		private void InitializeCB()
		{
			PriorityPicker.ItemsSource = storage.Get<IPriority>().ToList();
			TasksListPicker.ItemsSource = storage.Get<IPriority>().ToList();
		}

		private void RemoveButton_Clicked(object sender, EventArgs e)
		{
			Task.Delete();
			Navigation.PopAsync();
		}

		private void TasksListPicker_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void PriorityPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = 18389;
		}

		private void RepeatButton_Clicked(object sender, EventArgs e)
		{

		}

		private void SelectDatesRangeButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}