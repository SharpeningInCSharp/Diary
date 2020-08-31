using Diary.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OuterTaskCollection : ContentView
	{
		private readonly TaskViewModel taskViewModel;

		public OuterTaskCollection()
		{
			InitializeComponent();

			taskViewModel = DependencyService.Get<TaskViewModel>();
			//TODO: bind events
		}

		private void OnItemCompleted(object sender, EventArgs e)
		{
			if (sender is Layout<View> grid)
				taskViewModel.ItemCompleted(grid);
		}

		private void OnItemSelected(object sender, EventArgs args)
		{
			if (sender is BindableObject layout)
				taskViewModel.ItemSelected(Navigation, layout, TaskList);
		}
	}

	public partial class OuterTaskCollection
	{
		public static TodoModel.TaskList TaskList { private get; set; }
	}
}