using Diary.ViewModels;
using Realms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDetailsView : ContentPage
	{
		public TaskBase Task { get; }

		//TOOD: should pick out ViewModel with access to DB
		private ITodoStorage storage;
		private readonly TaskViewModel taskViewModel;

		public TaskDetailsView(TaskBase task)
		{
			InitializeComponent();

			taskViewModel = DependencyService.Get<TaskViewModel>();

			#region comm
			//InitializeCB();

			//old priority adding

			//PriorityPicker.ItemsSource = new List<IPriority>
			//{ Priority.Low, Priority.Hight, Priority.Normal};

			//reading priors from db 
			//var realm = Realm.GetInstance();
			//var priors = realm.All<PriorityEntity>().ToList();
			//List<IPriority> priorities = new List<IPriority>();
			//foreach(PriorityEntity pe in priors)
			//         {
			//	Priority savedOne = new Priority(pe.Name, pe.Value);
			//	savedOne.Color = System.Drawing.Color.FromArgb(pe.Color);
			//	priorities.Add(savedOne);
			//         }
			//PriorityPicker.ItemsSource = priorities;
			//

			//Task.PriorityChanged += Task_PriorityChanged;
			#endregion

			if(task is OuterTask)
				InnerTasksGrid.IsVisible = true;
			else
				InnerTasksGrid.IsVisible = false;

			//TODO: fill cb with TaskList titles
			//InitializeCB();

			BindingContext = Task = task ?? throw new ArgumentNullException(nameof(task));
		}

		private void InitializeCB()
		{
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

			if (HeaderEntry.Text == "") Task.Delete();
			Navigation.PopAsync(false);
		}

		private void PriorityBut_Clicked(object sender, EventArgs e)
		{
			PriorityView priorityView = new PriorityView(Task);
			priorityView.PriorityChanged += PriorityView_PriorityChanged;
			Navigation.PushAsync(priorityView, false);
		}

		private void PriorityView_PriorityChanged()
		{
			PriorityBut.Text = Task.Priority.Name;
			PriorityMarker.Fill = Task.Priority.Color;
		}

		private void AddSubtaskButton_Clicked(object sender, EventArgs e)
		{
			if (Task is OuterTask outerTask)
			{
				outerTask.Add(new Task());
			}
		}

		private void CrossButton_Clicked(object sender, EventArgs e)
		{
			var p = ((ImageButton)sender).Parent;
			if (p is Layout<View> layout)
			{
				var task = (TaskBase)layout.BindingContext;
				task.Delete();
			}
		}

		private void OnItemCompleted(object sender, EventArgs e)
		{
			if (sender is Layout<View> layout)
				taskViewModel.ItemCompleted(layout);
		}
	}
}