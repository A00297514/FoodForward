using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodForwardApp.Models
{
    /// <summary>
    /// The Volunteer class represents the details of a volunteer
    /// registering for the FoodForwardApp. It includes fields for capturing
    /// the volunteer's name, contact information, address, and estimated time.
    /// </summary>
    public class Volunteer
    {
        // Stores the Volunteer's Name
        public string Name { get; set; }

        // Stores the Volunteer's Number
        public string Number { get; set; }

        // Stores the Volunteer's Address
        public string Address { get; set; }

        // Stores the Estimated Time
        public string EstimatedTime { get; set; }
    }
}
