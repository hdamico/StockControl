using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStock.Models
{
    [Table("TiposProductos",Schema ="Productos")]
    public class TipoProducto
    {
        [Key]
        [Display(Name ="Id")]
        public int TipoProductoID { get; set; }
        
        [MaxLength(100,ErrorMessage ="El nombre del tipo de producto no debe exceder los 100 carateres")]
        [Display(Name ="Tipo de Producto")]
        [Column("TipoProducto")]
        [Required(ErrorMessage = "Nombre del tipo de producto requerido")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public TipoProducto()
        {
            this.Productos = new HashSet<Producto>();

        }
    }
}