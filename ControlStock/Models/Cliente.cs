using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("Clientes",Schema ="Clientes")]
    public class Cliente : Entidad
    {
        [MaxLength(20)]
        [Display(Name ="Codigo de Cliente")]
        public string Codigo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Nombre de Cliente")]
        public string Nombre { get; set; }
    }
}
