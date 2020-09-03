using Diary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PriorityView : ContentPage
	{
		public TaskBase task;
		public List<Priority> ListPriority = new List<Priority>();

		public delegate void UpdatePriority();
		public event UpdatePriority PriorityChanged;

		private readonly RealmDbViewModel realmDb;

		public PriorityView(TaskBase taskBase)
		{
			InitializeComponent();
			task = taskBase;

			realmDb = DependencyService.Get<RealmDbViewModel>();

			var realm = realmDb.GetDbInstance();
			var priors = realm.All<PriorityEntity>().ToList();

			foreach (PriorityEntity priority in priors)
				ListPriority.Add(new Priority(priority));

			MyListView.ItemsSource = ListPriority.OrderBy(i => i.Value);
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var pri = (Priority)MyListView.SelectedItem;
			((ListView)sender).SelectedItem = null;
			if (e.Item == null)
				return;
			task.Priority = new Priority(pri);
			
			PriorityChanged?.Invoke();
			await Navigation.PopAsync(false);
		}

		async private void AddItem_Clicked(object sender, EventArgs e)
		{
			AddPriorityView AddPriority = new AddPriorityView();
			AddPriority.PriorityListChanged += AddPriorityView_PriorityListChanged;
			await Navigation.PushAsync(AddPriority, false);
		}

		async private void AddPriorityView_PriorityListChanged()
		{
			var realm = realmDb.GetDbInstance();
			var priors = realm.All<PriorityEntity>().ToList();

			ListPriority.Clear();

			foreach (PriorityEntity priority in priors)
				ListPriority.Add(new Priority(priority));

			MyListView.ItemsSource = ListPriority.OrderBy(i => i.Value);
		}
	}
}
