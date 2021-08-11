namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        public int id { get; set; }

        public int id_order { get; set; }

        public int id_product { get; set; }

        public int quantity { get; set; }

        public virtual Order_ Order_ { get; set; }

        public virtual Product Product { get; set; }
    }
}
