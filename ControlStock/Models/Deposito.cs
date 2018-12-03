using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("Depositos",Schema ="Stock")]
    public class Deposito
    {
        [Key]
        public int DepositoID { get; set; }
        [Display(Name ="Deposito")]
        [Column("Deposito")]
        [MaxLength(100, ErrorMessage ="El nombre del deposito no debe exceder los 100 caracteres")]
        [Required(ErrorMessage ="Nombre del deposito requerido")]
        public string Nombre { get; set; }

        public TipoDeposito TipoDeposito { get; set; }
        public int TipoDepositoID { get; set; }

    }
}
