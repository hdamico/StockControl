using ControlStock.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.DAL
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                Marca Adidas = new Marca { Nombre = "Adidas" };
                Marca Topper = new Marca { Nombre = "Topper" };
                Marca NewBalance = new Marca { Nombre = "New Balance" };
                TipoProducto Vestimenta = new TipoProducto { Nombre = "Vestimenta" };
                TipoProducto Calzado = new TipoProducto { Nombre = "Calzado" };
                Rubro Indumentaria = new Rubro { Nombre= "Indumentaria" };

                if (!context.TiposComprobantes.Any())
                {
                    context.TiposComprobantes.Add(new TipoComprobante
                    { Columna = DebeHaber.Debe,
                    Nombre ="Factura Compras",
                    Sistema = CompraVenta.Compras
                    }
                    );
                    context.TiposComprobantes.Add(new TipoComprobante
                    {
                        Columna = DebeHaber.Haber,
                        Nombre = "Factura Ventas",
                        Sistema = CompraVenta.Ventas
                    }
                    );

                    // Seed Here
                }


                if (!context.TiposProductos.Any())
                {
                    context.TiposProductos.Add(Calzado);
                    context.TiposProductos.Add(Vestimenta);

                }
                if (!context.Marcas.Any())
                {
                    context.Marcas.Add(Adidas
                    );
                    context.Marcas.Add(NewBalance)
                    ;
                    context.Marcas.Add(Topper);

                }
                if (!context.Productos.Any())
                {
                    context.Productos.Add(new Producto
                    { Nombre = "Zapatilla Deportiva 01", Marca = NewBalance,
                        TipoProducto = Calzado , Rubro = Indumentaria }
                    );

                }


                context.SaveChanges();
            }
        }
    }
}
