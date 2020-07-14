using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDatailsView : ContentPage
	{
		public TaskBase Task { get; }

		public TaskDatailsView(TaskBase task = null)
		{
			InitializeComponent();

			if (task is null)
				task = new TodoModel.Task();

			BindingContext = Task = task;
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

		private void NoteEditor_TextChanged(object sender, TextChangedEventArgs e)
		{
			var h = Task.Header;
			var n = Task.Note;

			var n1 = NoteEditor.Text;
			var h1 = HeaderEntry.Text;
		}
	}
}