using ControlStock.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.ViewModels
{
    public class ProductoEdicionVM
    {
        public ProductoVM Edicion { get; set; }
    public List<SelectListItem> Marcas{ get; set; }
        public List<SelectListItem> Rubros { get; set; }
        public List<SelectListItem> TiposProductos { get; set; }
        
    }
}
