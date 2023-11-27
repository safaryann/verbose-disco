namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("discount")]
    public partial class DiscountEntity
    {
        public long ID { get; set; }

        public long Name { get; set; }

        [Column("discount percentage")]
        public long discount_percentage { get; set; }
    }
}
