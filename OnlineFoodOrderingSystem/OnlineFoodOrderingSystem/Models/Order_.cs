namespace OnlineFoodOrderingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int id { get; set; }

        public int id_customer { get; set; }

        public int id_state { get; set; }

        [StringLength(50)]
        public string delivery_address { get; set; }

        public DateTime? ordered_at { get; set; }

        public DateTime? es_delivery_at { get; set; }

        public DateTime? delivered_at { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(50)]
        public string total_price { get; set; }

        public virtual User_ User_ { get; set; }

        public virtual OrderState OrderState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
