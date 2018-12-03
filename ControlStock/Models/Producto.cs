using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("Productos",Schema ="Productos")]
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [Column("Producto")]
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        public Marca Marca { get; set; }
        public int MarcaID { get; set; }

        public TipoProducto TipoProducto { get; set; }
        public int TipoProductoID { get; set; }

        public Rubro Rubro { get; set; }
        public int RubroID { get; set; }

        public Producto()
        {

        }
    }
}
