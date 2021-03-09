namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(250)]
        public string ProductMetaTitle { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [StringLength(1000)]
        public string ProductLink { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        public DateTime? TopHot { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        public long? CategoryId { get; set; }
    }
}
