using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodForwardApp.Models
{
    /// <summary>
    ///The Registration class represents the process of registering a new user or organization
    /// within the FoodForwardApp. It includes fields for capturing essential registration details 
    /// such as the user's name, contact information, and any relevant organization details. 
    /// This class facilitates the onboarding of new participants and helps in maintaining 
    /// accurate records for communication and tracking purposes.
    /// </summary>


    public class Register
    {
        // Stores User Name from the Registration page
        public string Name { get; set; }

        // Stores Phone Number from the Registration page
        public string PhoneNum { get; set; }

        // Stores Email from the Registration page
        public string Email { get; set; }

        // Stores Password from the Registration page
        public string Password { get; set; }

        // Stores RePassword from the Registration page
        public string RePassword { get; set; }

        // Determines if the AcceptTerms checkbox is checked in the Registration page
        public bool AcceptTerms { get; set; }
    }
}
