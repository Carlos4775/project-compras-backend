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
        public DbSet<Unidades_Medida_Bd> Unidades_Medida { get; set; }
        public DbSet<Proveedores_Bd> Proveedores { get; set; }
        public DbSet<Orden_Compra_Bd> Orden_Compra { get; set; }
    }
}
