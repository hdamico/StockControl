using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("Comprobantes",Schema ="Stock")]
    public class Comprobante
    {
        [Key]
        public int ComprobanteID { get; set; }

        public TipoComprobante TipoComprobante { get; set; }
        public int TipoComprobanteID { get; set; }

        [MaxLength(50,ErrorMessage ="Numero de comprobante no debe exceder los 50 caracteres")]
        [Column("ComprobanteNumero")]
        [Display(Name ="Comprobante Nro")]
        public string NumeroComprobante { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fecha Requerida")]
        [Display(Name = "Fecha de Comprobante")]

        public Entidad Entidad { get; set; }
        public int EntidadID { get; set; }

        public string FechaComprobante { get; set; }

        public ICollection<DetalleComprobante> DetallesComprobantes { get; set; }

        public Comprobante()
        {
            this.DetallesComprobantes = new HashSet<DetalleComprobante>();

        }

    }
}
