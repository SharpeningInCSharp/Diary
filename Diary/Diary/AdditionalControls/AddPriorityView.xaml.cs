using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace Diary.AdditionalControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPriorityView : ContentPage
    {
        public Color PriorityColor = Color.Red;
        public Color MainColor;
        public int Value { get; set; }

        public AddPriorityView()
        {
            InitializeComponent();
            MainColor = Ell.Stroke;
            Value = 8;
            ValueLabel.Text = Value.ToString();
        }

        private void EllipseTapped(object sender, EventArgs e)
        {
            foreach (Ellipse ellipse in GridEllipse.Children)
                ellipse.Stroke = Color.Transparent;

            ((Ellipse)sender).Stroke = MainColor;
            PriorityColor = ((Ellipse)sender).Fill;
        }

        private void AddValue_Clicked(object sender, EventArgs e)
        {
            if (Value == 10) return;
            Value++;
            ValueLabel.Text = Value.ToString();
        }

        private void SubValue_Clicked(object sender, EventArgs e)
        {
            if (Value == 0) return;
            Value--;
            ValueLabel.Text = Value.ToString();
        }

        private void SavePriority_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}