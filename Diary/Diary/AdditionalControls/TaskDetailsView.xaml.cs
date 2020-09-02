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

		private readonly TaskViewModel taskViewModel;
		private readonly TaskList container;
		public delegate void UpdateList(Task a);
		public event UpdateList list_changed;
		public TaskDetailsView(TaskBase task, TaskList container = null)
		{
			InitializeComponent();

			taskViewModel = DependencyService.Get<TaskViewModel>();
			this.container = container;

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

			if (task is OuterTask)
			{
				InnerTasksGrid.IsVisible = true;
				InitializeCB(container);
			}
			else
				InnerTasksGrid.IsVisible = false;

			BindingContext = Task = task ?? throw new ArgumentNullException(nameof(task));
		}

		private void InitializeCB(TaskList container)
		{
			var db = taskViewModel.GetDbInstance();

			var collection = db.All<TaskListEntity>().ToList().Select(x => new TaskList(x)).ToList();

			TasksListPicker.ItemsSource = collection;
			//TasksListPicker.SelectedIndex = collection.IndexOf(container);
			TasksListPicker.SelectedItem = container;
		}

		private void RemoveButton_Clicked(object sender, EventArgs e)
		{
			Task.Delete();
			Navigation.PopAsync();
		}

		private async void TasksListPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var targetTasksList = ((Picker)sender).SelectedItem as TaskList ?? throw new ArgumentNullException("Picker selected item");

			if(container.Equals(targetTasksList) == false)
			{
				Task.MoveOut();

				targetTasksList.Add(Task);
				//TODO: save changes
			}
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

        private void SaveTaskButton_Clicked(object sender, EventArgs e)
        {
			var db = (new RealmDbViewModel()).GetDbInstance();
			db.Write(() =>
			{
				Settings newSet = new Settings()
				{
					Param = "Notes",
					value = db.All<Settings>().First(x => x.Param == "Notes").value + 1
				};
				db.Add(newSet, update: true);

				TodoNote newNote = new TodoNote();
				newNote.Id = db.All<Settings>().First(x => x.Param == "Notes").value;
				newNote.header = HeaderEntry.Text;
				newNote.Note = NoteEditor.Text;
				newNote.Priority = db.All<PriorityEntity>().First(x => x.Name == PriorityBut.Text);
				newNote.IsCompleted = false;
				newNote.taskList = db.All<TaskListEntity>().First(x => x.Name == ((TaskList)TasksListPicker.SelectedItem).Title);
				newNote.HasInners = false;
				db.Add(newNote);

				TaskListEntity a = db.All<TaskListEntity>().First(x => x.Name == ((TaskList)TasksListPicker.SelectedItem).Title);
				a.notes.Add(newNote);

				Task b = new Task();
				b.Header = newNote.header;
				b.Note = newNote.Note;
				b.Priority = new Priority(newNote.Priority); 
				list_changed?.Invoke(b);
			});
			DisplayAlert("Сохранение", "Успешно", "Ок");
		}
    }
}