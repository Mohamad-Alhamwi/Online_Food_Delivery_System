namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int id { get; set; }

        public int? id_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string report_title { get; set; }

        [Required]
        [StringLength(500)]
        public string report_description { get; set; }

        public DateTime issued_at { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
