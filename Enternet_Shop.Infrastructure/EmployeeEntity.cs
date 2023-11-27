namespace Enternet_Shop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class EmployeeEntity
    {
        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Column("Date of birth")]
        public long Date_of_birth { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        public long Experience { get; set; }

        [Column("Work schedule")]
        public long Work_schedule { get; set; }
    }
}
