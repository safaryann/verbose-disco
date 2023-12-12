namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("client")]
    public partial class ClientEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientEntity()
        {
            order = new HashSet<OrderEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Column("date of birth")]
        public string date_of_birth { get; set; }
        [Required]
        [StringLength(2147483647)]
        public string Password { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Login { get; set; }
        public long PostId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntity> order { get; set; }
        public virtual PostEntity post { get; set; }
    }
}
