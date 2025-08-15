using Microsoft.EntityFrameworkCore;
using ShopDomain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options) 
        {
            
        }


        public DbSet<Articulo> articulos { get; set; }  
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<Tiendas> tiendas { get; set; }
        public DbSet<ArtTienda> artTiendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
              .HasIndex(u => u.Username)
              .IsUnique();
            modelBuilder.ApplyConfiguration(new ClientSeed());

            modelBuilder.Entity<ArtTienda>()
              .HasIndex(s => new { s.StoreId, s.ArticuloId })
              .IsUnique();

            modelBuilder.Entity<Sales>()
              .HasIndex(s => new { s.ClientId, s.ArticuloId })
              .IsUnique();

           
            modelBuilder.Entity<ArtTienda>()
                .HasOne(at => at.Articulo)
                .WithMany(a => a.ArtTienda)
                .HasForeignKey(at => at.ArticuloId);

            modelBuilder.Entity<ArtTienda>()
                .HasOne(at => at.Tiendas)
                .WithMany(t => t.ArtTienda)
                .HasForeignKey(at => at.StoreId);

            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Cliente)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.ClientId);

        
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Articulo)
                .WithMany(a => a.Sales)
                .HasForeignKey(s => s.ArticuloId);

    
            modelBuilder.Entity<Sales>()
                .HasIndex(s => new { s.ClientId, s.ArticuloId })
                .IsUnique();


        }

    }
}
