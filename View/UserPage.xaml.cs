

using Microsoft.Maui.Controls;
using FoodForwardApp.Models;
//using Windows.System;

namespace FoodForwardApp.View    
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            //InitializeComponent();
            BindingContext = new User();
            //{
            //    UserId = 0,
            //    Name = "",
            //    Email = "",
            //    Password = "",
            //    ContactNumber = "",
            //    Address = "",
            //    IsAdmin = false
            //};
        }
    }
}
