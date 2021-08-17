namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            MenuItem = new HashSet<MenuItem>();
            OrderItem = new HashSet<OrderItem>();
            UserFavourite = new HashSet<UserFavourite>();
            UserRating = new HashSet<UserRating>();
        }

        public int id { get; set; }

        public int id_restaurant { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        public decimal price { get; set; }

        public decimal product_weight { get; set; }

        [Required]
        [StringLength(500)]
        public string product_description { get; set; }

        [Column(TypeName = "image")]
        public byte[] product_image { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public int category_id { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuItem> MenuItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFavourite> UserFavourite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRating> UserRating { get; set; }
    }
}
