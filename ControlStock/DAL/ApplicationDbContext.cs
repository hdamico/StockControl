using ControlStock.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStock.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        
        public class EntidadConfiguration : IEntityTypeConfiguration<Entidad>
        {
            public void Configure(EntityTypeBuilder<Entidad> builder)
            {
                builder.HasKey(o => o.EntidadID);
                builder.ToTable("Entidades", "Entidades");




            }
        }
            public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
        {
            public void Configure(EntityTypeBuilder<Marca> builder)
            {
                builder.HasKey(o => o.MarcaID);
                builder.Property(t => t.Nombre)
                .IsRequired()
                .HasColumnName("Marca");
                builder.ToTable("Marcas","Productos");
                

            //    .HasColumnType("Date")
            //    .HasDefaultValueSql("GetDate()");
            //
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
                builder.ApplyConfiguration(new MarcaConfiguration());

            builder.Entity<Entidad>().Property(b => b.EntidadID)
            .HasColumnName("EntidadID");
            builder.Entity<Entidad>().Property(b => b.TipoEntidad)
            .HasColumnName("TipoEntidad");
            builder.Entity<Proveedor>().Property(b => b.EntidadID)
            .HasColumnName("EntidadID");
            builder.Entity<Proveedor>().Property(b => b.CUIT)
            .HasColumnName("CUIT");
            builder.Entity<Proveedor>().Property(b => b.RazonSocial)
            .HasColumnName("Razon Social");
            builder.Entity<Cliente>().Property(b => b.EntidadID)
            .HasColumnName("EntidadID");
            builder.Entity<Cliente>().Property(b => b.Nombre)
                        .HasColumnName("Cliente");
            builder.Entity<Cliente>().Property(b => b.Codigo)
            .HasColumnName("Codigo");

            builder.Entity<Cliente>().ToTable("Clientes");
            builder.Entity<Proveedor>().ToTable("Proveedores");



            // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            // look at this answer: https://stackoverflow.com/a/43075152/3419825
            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                
                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }




            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoComprobante> TiposComprobantes { get; set; }
        public DbSet<TipoDeposito> TiposDepositos { get; set; }
        public DbSet<TipoProducto> TiposProductos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
