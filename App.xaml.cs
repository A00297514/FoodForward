using FoodForwardApp.Models;
namespace FoodForwardApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UserPage();
        }
    }
}
