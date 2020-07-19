using Realms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDetailsView : ContentPage
	{
		public TaskBase Task { get; }

		//TOOD: should pick out ViewModel with access to DB
		private ITodoStorage storage;
		public TaskDetailsView(TaskBase task)
		{
			InitializeComponent();

            //InitializeCB();

            //old priority adding

            PriorityPicker.ItemsSource = new List<IPriority>
            { Priority.Low, Priority.Hight, Priority.Normal};

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

		async private void PriorityBut_Clicked(object sender, EventArgs e)
		{

		}
	}
}