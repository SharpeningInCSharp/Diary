using System;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDatailsView : ContentPage
	{
		public TaskBase Task { get; }

		public TaskDatailsView(TaskBase task)
		{
			InitializeComponent();

			BindingContext = Task = task ?? throw new ArgumentNullException(nameof(task));
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

		}

		private void RepeatButton_Clicked(object sender, EventArgs e)
		{

		}

		private void SelectDatesRangeButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}