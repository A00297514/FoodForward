using Microsoft.Maui.Controls;
using FoodForwardApp.Models;

namespace FoodForwardApp.View;


    public partial class FoodItemPage : ContentPage
{
    public FoodItemPage()
    {
       // InitializeComponent();
        BindingContext = new FoodItem
        {
            ItemId = 0,
            Name = "",
            Quantity = 0,
            ExpirationDate = DateTime.Now,
            Category = "Fruits",
            Description = "",
            Weight = 0.0
        };
    }
}
