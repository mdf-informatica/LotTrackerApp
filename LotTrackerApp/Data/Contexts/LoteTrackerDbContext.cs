using LotTrackerApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LotTrackerApp.Data.Contexts
{
    public class LoteTrackerDbContext : DbContext
    {
        public LoteTrackerDbContext(DbContextOptions<LoteTrackerDbContext> options) :base(options)
        {
        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoLote> ProdutoLote { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<ProdutoFabricante> ProdutoFabricante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoLote>().HasKey(b => new { b.Produto, b.Lote });
            modelBuilder.Entity<ProdutoFabricante>().HasKey(b => new { b.Produto, b.Fabricante });
            modelBuilder.Entity<ProdutoFabricante>().HasOne(b => b.Pais);

            modelBuilder.Entity<Produto>(p =>
            {
                p.Property(b => b.TipoProduto).HasConversion<string>();
                p.Property(b => b.Familia).HasConversion<string>();
            });


          /*  modelBuilder.Entity<IdentityUserLogin<String>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<String>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<String>>().HasNoKey();*/

        }
    }
}
