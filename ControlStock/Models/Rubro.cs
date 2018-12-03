using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStock.Models
{
    [Table("Rubros",Schema = "Productos")]
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre del rubro no debe exceder los 100 carateres")]
        [Display(Name = "Rubro")]
        [Column("Rubro")]
        [Required(ErrorMessage = "Nombre del rubro requerido")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public Rubro()
        {
            this.Productos = new HashSet<Producto>();

        }
    }
}