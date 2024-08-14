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


    using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\+91\s\d{10}$", ErrorMessage = "Phone number must be 10 digits long and start with +91")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool AcceptTerms { get; set; }
    }
}