using System.Windows;

namespace FoodForwardApp
{
    public partial class VolunteerPage : ContentPage
    {
        public VolunteerPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.VolunteerViewModel();
        }
    }
}
