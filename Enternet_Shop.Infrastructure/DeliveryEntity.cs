namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("delivery")]
    public partial class DeliveryEntity
    {
        public long ID { get; set; }

        [Column("adress")]
        [Required]
        [StringLength(2147483647)]
        public string Adress { get; set; }

        [Column("ID order")]
        public long ID_order { get; set; }

        [Column("ID warehouse")]
        public long ID_warehouse { get; set; }

        public virtual OrderEntity order { get; set; }

        public virtual WarehouseEntity warehouse { get; set; }
    }
}
