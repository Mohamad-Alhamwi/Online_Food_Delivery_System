namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentCard")]
    public partial class PaymentCard
    {
        public int id { get; set; }

        public int id_user { get; set; }

        [Required]
        [StringLength(50)]
        public string card_name { get; set; }

        [Required]
        [StringLength(50)]
        public string card_no { get; set; }

        public DateTime expiration_data { get; set; }

        public int cvv { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
