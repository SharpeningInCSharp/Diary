using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoModel;
using TodoModel.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriorityView : ContentPage
    {
        public List<PriorityModelView> ListPriority = new List<PriorityModelView>();

        public class PriorityModelView
        {
            public PriorityModelView(PriorityEntity entity)
            {
                Name = entity.Name;
                Value = entity.Value;
                System.Drawing.Color color1 = System.Drawing.Color.FromArgb(entity.Color);
                PriorityColor = Color.FromRgb(color1.R, color1.G, color1.B);
            }
            public string Name { get; set; }
            public int Value { get; set; }
            public Color PriorityColor { get; set; }
        }

        public PriorityView()
        {
            InitializeComponent();

            var realm = Realm.GetInstance();
            var priors = realm.All<PriorityEntity>().ToList();

            foreach(PriorityEntity priority in priors)
                ListPriority.Add(new PriorityModelView(priority));

            MyListView.ItemsSource = ListPriority;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
