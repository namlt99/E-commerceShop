namespace Models._01.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductImage")]
    public partial class ProductImage
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(2000)]
        public string FileName { get; set; }

        [StringLength(2000)]
        public string FilePhysicalName { get; set; }

        public int? IsMainImage { get; set; }
    }
}
