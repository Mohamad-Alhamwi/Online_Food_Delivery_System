namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public int id { get; set; }

        public int id_user { get; set; }

        public int id_role { get; set; }

        public virtual Role_ Role_ { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
