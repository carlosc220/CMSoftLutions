namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Producto")]
        [NotMapped]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        [MaxLength(12, ErrorMessage = "Maximo 12 Números")]
        [Range(0, 999999999999.99, ErrorMessage = "Valor fuera del Rango")]
        [DisplayName("Cantidad")]
        public virtual string QuantityString { get; set; }

        [Column(TypeName = "numeric")]
        [DataType(DataType.Currency, ErrorMessage = "Solo Números")]
        [DisplayName("Valor")]
        public decimal Value { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }
    }
}
