namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAddress")]
    public partial class UserAddress
    {
        public int id { get; set; }

        public int id_user { get; set; }

        public int id_address { get; set; }

        public virtual Address_ Address_ { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
