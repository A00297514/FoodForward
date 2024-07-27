using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForwardApp.Models
{
    /// <summary>
    /// The User class represents a user in the food donation app. 
    /// It contains details such as the user's ID, name, email, password, 
    /// contact number, and address. These attributes are essential for 
    /// managing user accounts and enabling them to interact with the 
    /// donation system. The user's address helps in locating potential 
    /// donation pickups or deliveries.
    /// </summary>
    public class User
    {
        // Unique identifier for the user
        public int UserId { get; set; }

        // Full name of the user
        public string Name { get; set; }

        // Email address used for login
        public string Email { get; set; }

        // Password for account security
        public string Password { get; set; }

        // Contact number of the user
        public string ContactNumber { get; set; }

        // Physical address of the user
        public string Address { get; set; }

        // Determines if the user is an administrator
        public bool IsAdmin { get; set; }
    }
}
