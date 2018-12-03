using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlStock.Models
{
    [Table("Marcas",Schema ="Productos")]
    public class Marca
    {
        [Key]
        [Display(Name ="Id")]
        public int MarcaID { get; set; }

        [Required(ErrorMessage = "Marca Requerida")]
        [MaxLength(100)]
        [Column("Marca")]
        [Display(Name ="Marca")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
        public Marca()
        {
            this.Productos = new HashSet<Producto>();

        }
    }
}