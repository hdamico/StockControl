using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    public enum DebeHaber { Debe,Haber }
    public enum CompraVenta {Compras,Ventas }
    [Table("TiposComprobantes",Schema = "Stock")]
    public class TipoComprobante
    {
        [Key]
        public int TipoComprobanteID { get; set; }

        [Display(Name ="Tipo de Comprobante")]
        [MaxLength(100,ErrorMessage ="El tipo de comprobante no debe exceder los 100 carateres")]
        [Required(ErrorMessage ="El tipo de comprobante es requerido")]
        [Column("TipoComprobante")]
        public string Nombre { get; set; }

        public DebeHaber Columna { get; set; }
        public CompraVenta Sistema { get; set; }

        public ICollection<Comprobante> Comprobantes { get; set; }
        public TipoComprobante()
        {
            this.Comprobantes = new HashSet<Comprobante>();

        }
    }
}
