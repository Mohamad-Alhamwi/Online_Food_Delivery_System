namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int id { get; set; }

        public int id_product { get; set; }

        public int id_category { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
