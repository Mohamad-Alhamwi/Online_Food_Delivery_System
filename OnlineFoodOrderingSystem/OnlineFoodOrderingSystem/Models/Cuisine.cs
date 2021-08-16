namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cuisine")]
    public partial class Cuisine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuisine()
        {}

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string cuisine_name { get; set; }
    }
}
