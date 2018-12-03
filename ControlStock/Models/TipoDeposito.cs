using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    [Table("TiposDepositos",Schema ="Stock")]
    public class TipoDeposito
    {
        [Key]
        public int TipoDepositoID { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre del tipo de deposito no debe exceder los 100 carateres")]
        [Display(Name = "Tipo de Deposito")]
        [Column("TipoDeposito")]
        [Required(ErrorMessage = "Nombre del tipo de deposito requerido")]
        public string Nombre { get; set; }

        public ICollection<Deposito> Depositos { get; set; }

        public TipoDeposito()
        {
            this.Depositos = new HashSet<Deposito>();

        }
    }
}
