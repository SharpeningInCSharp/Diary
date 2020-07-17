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

			//InitializeCB();
			PriorityPicker.ItemsSource = new List<IPriority>
			{ Priority.Low, Priority.Hight, Priority.Normal};

			BindingContext = Task = task ?? throw new ArgumentNullException(nameof(task));
		}

		private void InitializeCB()
		{
			PriorityPicker.ItemsSource = storage.Get<IPriority>().ToList();
			TasksListPicker.ItemsSource = storage.Get<ITodoStorage>().ToList();
		}

		private void RemoveButton_Clicked(object sender, EventArgs e)
		{
			Task.Delete();
			Navigation.PopAsync();
		}

		private async void TasksListPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var targetTasksList = ((Picker)sender).SelectedItem;

			//TODO: should be await
			Task.MoveOut();

			await System.Threading.Tasks.Task.Run(() =>
					storage.Get<TaskList>().SingleOrDefault(x => x.Equals(targetTasksList)).Add(Task));
		}


		private void RepeatButton_Clicked(object sender, EventArgs e)
		{

		}

		private void SelectDatesRangeButton_Clicked(object sender, EventArgs e)
		{

		}

		async private void CloseButton_Clicked(object sender, EventArgs e)
		{
			await CloseButton.RotateTo(0, 200, Easing.CubicInOut);
			Navigation.PopAsync(false);
		}
	}
}