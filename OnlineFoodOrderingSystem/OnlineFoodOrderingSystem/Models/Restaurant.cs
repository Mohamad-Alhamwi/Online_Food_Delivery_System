namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurant")]
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            Menu = new HashSet<Menu>();
            Product = new HashSet<Product>();
        }

        public int id { get; set; }

        public int id_seller { get; set; }

        [Required]
        [StringLength(50)]
        public string restaurant_name { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string town { get; set; }

        [Column(TypeName = "image")]
        public byte[] logo { get; set; }

        public int cuisine_id { get; set; }

        public virtual Cuisine Cuisine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
