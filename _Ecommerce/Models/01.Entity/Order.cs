namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        public long? UserId { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "ntext")]
        public string ShipNote { get; set; }

        public long? GiftCodeId { get; set; }

        public int? Status { get; set; }

        public decimal? Total { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}
