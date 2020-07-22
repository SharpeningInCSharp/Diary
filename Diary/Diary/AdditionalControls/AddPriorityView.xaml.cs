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

        public AddPriorityView()
        {
            InitializeComponent();
        }

        private void EllipseTapped(object sender, EventArgs e)
        {
            foreach (Ellipse ellipse in GridEllipse.Children)
                ellipse.Stroke = Color.Transparent;

            ((Ellipse)sender).Stroke = new Color(217,199,184);
            PriorityColor = ((Ellipse)sender).Fill;
        }
    }
}