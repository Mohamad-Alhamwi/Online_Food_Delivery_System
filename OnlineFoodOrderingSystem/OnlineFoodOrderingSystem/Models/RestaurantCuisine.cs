namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantCuisine")]
    public partial class RestaurantCuisine
    {
        public int id { get; set; }

        public int id_restaurant { get; set; }

        public int id_cuisine { get; set; }

        public virtual Cuisine Cuisine { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
