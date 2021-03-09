namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public long? CodeConfirm { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Avatar { get; set; }

        [StringLength(50)]
        public string NumberPhone { get; set; }

        public int? Gender { get; set; }

        public int? Level { get; set; }

        public int? Status { get; set; }
    }
}
