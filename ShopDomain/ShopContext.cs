using Microsoft.EntityFrameworkCore;
using ShopDomain.Entities;
using System;
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


    }
}
