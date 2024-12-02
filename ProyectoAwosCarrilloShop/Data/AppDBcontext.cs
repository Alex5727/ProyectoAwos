using Microsoft.EntityFrameworkCore;
using ProyectoAwosCarrilloShop.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoAwosCarrilloShop.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
           .HasKey(c => c.CliID);

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Carrito>()
                .HasKey(c => c.CarritoID);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Cliente)
            .WithOne(c => c.Carrito)
            .HasForeignKey<Carrito>(c => c.CliID);

            modelBuilder.Entity<DetalleCarrito>()
            .HasKey(dc => new { dc.CarritoID, dc.ID });

            modelBuilder.Entity<DetalleCarrito>()
                .HasOne(b => b.Carrito)
                .WithMany(ba => ba.DetallesCarrito)
                .HasForeignKey(bi => bi.CarritoID);

            modelBuilder.Entity<DetalleCarrito>()
                .HasOne(b => b.Producto)
                .WithMany(ba => ba.DetallesCarrito)
                .HasForeignKey(bi => bi.ID);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<DetalleCarrito> DetallesCarrito { get; set; }
    }
}
