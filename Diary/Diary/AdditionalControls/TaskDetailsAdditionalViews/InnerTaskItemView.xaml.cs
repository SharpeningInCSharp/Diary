using System;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls.TaskDetailsAdditionalViews
{
	/// <summary>
	/// This item's used for displayng and editing <see cref="TaskBase"/> title, its completing and deleting.
	/// It doesn't supposed view Task details
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InnerTaskItemView : ContentView
	{
		private readonly TaskBase innerTask;
		public InnerTaskItemView(TaskBase innerTask)
		{
			InitializeComponent();

			this.innerTask = innerTask;
		}

		private void CrossButton_Clicked(object sender, EventArgs e)
		{
			innerTask.Delete();
		}
	}
}