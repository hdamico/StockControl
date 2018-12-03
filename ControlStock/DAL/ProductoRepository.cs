using ControlStock.Models;
using ControlStock.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ControlStock.DAL
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext context):base(context )
        {

        }
        public ProductoEdicionVM Get_Edicion(int? id)
        {
            ProductoEdicionVM re = new ProductoEdicionVM();
            re.Edicion = ProductoContext.Productos.Where(c => c.ProductoID == id)
                .Select(s => new ProductoVM {
                    ProductoID = s.ProductoID,
                    Marca = s.Marca.Nombre,
                    MarcaID = s.MarcaID,
                    Nombre = s.Nombre,
                    Rubro= s.Rubro.Nombre,
                    RubroID = s.RubroID,
                    TipoProducto = s.TipoProducto.Nombre,
                    TipoProductoID = s.TipoProductoID
                }).FirstOrDefault();
            re.Marcas = ProductoContext.Marcas.Select(s => new SelectListItem { Value = s.MarcaID.ToString(), Text = s.Nombre 
                //, Selected = (s.MarcaID== re.Edicion.MarcaID)
            }).ToList();
            re.Rubros = ProductoContext.Rubros.Select(s => new SelectListItem
            { Value = s.RubroID.ToString(), Text = s.Nombre
            //, Selected = (s.RubroID== re.Edicion.RubroID)
            }).ToList();
            re.TiposProductos = ProductoContext.TiposProductos.Select(s => new SelectListItem
            { Value = s.TipoProductoID.ToString(),
                Text = s.Nombre
                //, Selected = (s.TipoProductoID== re.Edicion.TipoProductoID)
            } ).ToList();

            return re;
        }

        public List<ProductoVM> Grilla()
        {
            return ProductoContext.Productos.Select(s =>
            new ProductoVM {  Marca = s.Marca.Nombre, MarcaID = s.MarcaID, Nombre = s.Nombre,
                ProductoID = s.ProductoID, Rubro = s.Rubro.Nombre, RubroID = s.RubroID, TipoProducto = s.TipoProducto.Nombre
            , TipoProductoID = s.TipoProductoID }).ToList(); 
            
        }

        public bool Add(ProductoVM vm)
        {
            return this.Add(new Producto
            { ProductoID =vm.ProductoID,
             MarcaID = vm.MarcaID,
            RubroID = vm.RubroID,
            TipoProductoID = vm.TipoProductoID,
            Nombre = vm.Nombre}
            );
        }

        public bool Update(ProductoVM vm)
        {
            return this.Update(new Producto
            {
                ProductoID = vm.ProductoID,
                MarcaID = vm.MarcaID,
                RubroID = vm.RubroID,
                TipoProductoID = vm.TipoProductoID,
                Nombre = vm.Nombre
            });
        }

        public PagedList<ProductoVM> PageGrid(int size = 10, int page = 1, string filter = "", string sort = "Nombre", string sordir = "ASC")
        {
            var records = new PagedList<ProductoVM>();

            records.Content = ProductoContext.Productos
                 .Where(x => (filter == null)
                        || (x.Nombre.Contains(filter))
                        || (x.Marca.Nombre.Contains(filter)))
                        .Select(s =>
           new ProductoVM
           {
               Marca = s.Marca.Nombre,
               MarcaID = s.MarcaID,
               Nombre = s.Nombre,
               ProductoID = s.ProductoID,
               Rubro = s.Rubro.Nombre,
               RubroID = s.RubroID,
               TipoProducto = s.TipoProducto.Nombre
           ,
               TipoProductoID = s.TipoProductoID
           }).Skip(page - 1)
           .Take(size)
          .ToList();

            records.TotalRecords =  ProductoContext.Productos
                 .Where(x => (filter == null)
                        || (x.Nombre.Contains(filter))
                        || (x.Marca.Nombre.Contains(filter))).Count();
            return records;
        }
     
        public ApplicationDbContext ProductoContext
        {
            get{ return context  as ApplicationDbContext; }

        }
    }
}
