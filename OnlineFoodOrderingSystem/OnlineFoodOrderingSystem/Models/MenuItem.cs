namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuItem")]
    public partial class MenuItem
    {
        public int id { get; set; }

        public int id_Menu { get; set; }

        public int id_product { get; set; }

        public int quantity { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Product Product { get; set; }
    }
}
