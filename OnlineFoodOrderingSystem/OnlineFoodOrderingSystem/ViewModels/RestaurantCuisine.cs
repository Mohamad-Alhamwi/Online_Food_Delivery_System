using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFoodOrderingSystem.Models;


namespace OnlineFoodOrderingSystem.ViewModels
{
    public class RestaurantCuisine
    {
        public int restaurantId { get; set; }
        public string restaurantName { get; set; }
        public string restaurantTown { get; set; }
        public byte[] restaurantLogo { get; set; }
        public string cuisineName { get; set; }
    }
}
