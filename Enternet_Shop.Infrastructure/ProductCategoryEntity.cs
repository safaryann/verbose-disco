namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product category")]
    public partial class ProductCategoryEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategoryEntity()
        {
            product = new HashSet<ProductEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductEntity> product { get; set; }
    }
}
