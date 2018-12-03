using ControlStock.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.Models
{
    public class TipoProductoRepository : GenericRepository<TipoProducto>
    {
        
        public TipoProductoRepository(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
