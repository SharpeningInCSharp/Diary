using System;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskItemView : ContentView
	{
		/// <summary>
		/// Object to be binded to Context
		/// </summary>
		public Task Task { get; set; }

		public TaskItemView()
		{
			InitializeComponent();
			BindingContext = Task;
		}

		public TaskItemView(Task task) : this()
		{
			Task = task;

			//TODO: develop Complete button
			if (task.HasInners)
				task.TaskCompleted += Task_TaskCompleted;
		}

		private void Task_TaskCompleted(TaskBase task)
		{
			//TODO: complete all inners
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			//TODO: open page with this item
		}
	}
}