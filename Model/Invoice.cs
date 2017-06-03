namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalValue { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
