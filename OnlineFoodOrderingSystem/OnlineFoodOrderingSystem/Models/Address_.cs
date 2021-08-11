namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address_()
        {
            UserAddress = new HashSet<UserAddress>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string address_name { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string town { get; set; }

        [Required]
        [StringLength(50)]
        public string neighborhood { get; set; }

        [Required]
        [StringLength(50)]
        public string street { get; set; }

        [Required]
        [StringLength(50)]
        public string building_name { get; set; }

        public int building_no { get; set; }

        public int flat_no { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAddress> UserAddress { get; set; }
    }
}
