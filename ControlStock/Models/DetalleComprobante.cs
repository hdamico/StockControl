using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("DetallesComprobantes" , Schema ="Stock")]
    public class DetalleComprobante
    {
        [Key]
        public int DetalleComprbanteID { get; set; }
        public int ComprobanteID { get; set; }
        public Comprobante Comprobante { get; set; }

        public Producto Producto { get; set; }
        public int ProductoID { get; set; }

        public int Cantidad { get; set; }

        [DataType("decimal(16 ,2")]
        [Required]
        public decimal Importe { get; set; }
    }
}
