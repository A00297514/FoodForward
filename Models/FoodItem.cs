using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForwardApp.Models
{
    /// <summary>
    /// The FoodItem class represents a single item of food 
    /// that can be donated or is part of a donation. 
    /// It includes details like the ItemId, Name, Quantity, 
    /// ExpirationDate, Category, and a Description. This 
    /// class helps categorize and manage food donations, 
    /// ensuring food safety and proper inventory tracking. 
    /// The expiration date ensures the item is safe for 
    /// consumption before it is donated.
    /// </summary>
    public class FoodItem
    {
        // Unique identifier for the food item
        public int ItemId { get; set; }

        // Name of the food item
        public string Name { get; set; }

        // Quantity of the food item available for donation
        public int Quantity { get; set; }

        // Expiration date of the food item
        public DateTime ExpirationDate { get; set; }

        // Category of the food item (e.g., Fruits, Vegetables, Canned Goods)
        public string Category { get; set; }

        // Description of the food item
        public string Description { get; set; }

        // Weight of the food item in kilograms
        public double Weight { get; set; }
    }
}