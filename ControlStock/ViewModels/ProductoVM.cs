using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.ViewModels
{
    public class ProductoVM
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        public string Marca { get; set; }
        public int MarcaID { get; set; }

        public string TipoProducto { get; set; }
        public int TipoProductoID { get; set; }

        public string Rubro { get; set; }
        public int RubroID { get; set; }
    }
}
