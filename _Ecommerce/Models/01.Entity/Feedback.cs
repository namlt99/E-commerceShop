namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public long ID { get; set; }

        public long? UserId { get; set; }

        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }
    }
}
