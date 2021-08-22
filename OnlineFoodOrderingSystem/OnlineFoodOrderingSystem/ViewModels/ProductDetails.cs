using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.ViewModels
{
    public class ProductDetails
    {
        public int cuisineId { get; set; }
        public int restaurantId { get; set; }
        public int categoryId { get; set; }
        public int productId { get; set; }
        public string restaurantName { get; set; }
        public string categoryName { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal productPrice { get; set; }
        public decimal productWeight { get; set; }
        public byte[] productImage { get; set; }
    }
}