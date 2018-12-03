using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("Proveedores",Schema ="Proveedores")]
    public class Proveedor:Entidad
    {
        public string CUIT { get; set; }
        [Display(Name ="Razon Social")]
        public string RazonSocial { get; set; }


    }
}
