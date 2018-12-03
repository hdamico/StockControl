using ControlStock.Models;
using ControlStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.DAL
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        List<ProductoVM> Grilla();
        ProductoEdicionVM Get_Edicion(int? id);
        bool Add(ProductoVM vm);
        bool Update(ProductoVM vm);
        PagedList<ProductoVM> PageGrid(int size = 10, int page = 1,string filter=null, string sort = "Nombre", string sordir = "ASC");
        
    }
}
