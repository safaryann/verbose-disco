namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class OrderEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderEntity()
        {
            delivery = new HashSet<DeliveryEntity>();
        }

        public long ID { get; set; }

        public long Number { get; set; }

        public long date { get; set; }

        [Column("ID status")]
        public long ID_status { get; set; }

        [Column("ID client")]
        public long ID_client { get; set; }

        public virtual ClientEntity client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryEntity> delivery { get; set; }

        public virtual StatusEntity status_ { get; set; }
    }
}
