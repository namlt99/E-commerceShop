namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalProductPrice { get; set; }

        public long? ProductID { get; set; }
    }
}
