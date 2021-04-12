using apiCompras.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCompras.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Departamentos_Bd> Departamentos { get; set; }
        public DbSet<Articulos_Bd> Articulos { get; set; }
        public DbSet<Unidades_Medida_Bd> Unidades_Medidas { get; set; }
        public DbSet<Proveedores_Bd> Proveedores { get; set; }
        public DbSet<Orden_Compra_Bd> Orden_Compra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos_Bd>()
                .HasOne(p => p.Unidad_Medida)
                .WithMany(b => b.Articulos)
                .HasForeignKey(p => p.Id_Unidad_Medida);

            modelBuilder.Entity<Orden_Compra_Bd>()
                .HasOne(p => p.Articulo)
                .WithMany(b => b.Ordenes_Compras)
                .HasForeignKey(p => p.Id_Articulo);

            modelBuilder.Entity<Orden_Compra_Bd>()
                .HasOne(p => p.Unidad_Medida)
                .WithMany(b => b.Ordenes_Compras)
                .HasForeignKey(p => p.Id_Unidad_Medida);

            modelBuilder.Entity<Orden_Compra_Bd>()
                .HasOne(p => p.Proveedor)
                .WithMany(b => b.Ordenes_Compras)
                .HasForeignKey(p => p.Id_Proveedor);

            modelBuilder.Entity<Orden_Compra_Bd>()
                .HasOne(p => p.Departamento)
                .WithMany(b => b.Ordenes_Compras)
                .HasForeignKey(p => p.Id_Departamento);

        }
    }
}
