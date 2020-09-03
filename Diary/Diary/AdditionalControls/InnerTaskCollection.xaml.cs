using Diary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InnerTaskCollection : ContentView
	{
		private const int SingleCollectionItemSize = 60;
		private readonly TaskViewModel taskViewModel;

		public InnerTaskCollection()
		{
			InitializeComponent();

			taskViewModel = DependencyService.Get<TaskViewModel>();
		}

		private void OnItemCompleted(object sender, EventArgs e)
		{
			if(sender is Layout<View> layout)
				taskViewModel.ItemCompleted(layout);
		}

		private void OnItemSelected(object sender, EventArgs e)
		{
			if (sender is BindableObject layout)
				taskViewModel.ItemSelected(Navigation, layout);
		}

		private void InnerColl_BindingContextChanged(object sender, EventArgs e)
		{
			if (BindingContext is IEnumerable<TaskBase> taskCollection)
			{
				InnerTasksCollectionView.ItemsSource = taskCollection;
				InnerTasksCollectionView.HeightRequest = taskCollection.Count() * SingleCollectionItemSize;
			}
			else
			{
				InnerTasksCollectionView.HeightRequest = 0;
			}
		}
	}
}