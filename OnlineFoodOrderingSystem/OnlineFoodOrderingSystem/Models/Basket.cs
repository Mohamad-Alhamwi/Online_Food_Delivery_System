namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        public int id { get; set; }

        public int id_product { get; set; }

        public int id_user { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
