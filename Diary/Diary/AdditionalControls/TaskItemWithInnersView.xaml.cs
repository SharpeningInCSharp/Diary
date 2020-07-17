using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskItemWithInnersView : ContentView
	{
		public Task Task { get; set; }

		public TaskItemWithInnersView()
		{
			InitializeComponent();

			BindingContext = MainItem.Task = Task;
		}
	}
}