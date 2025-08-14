using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain
{
    public class ClientSeed : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            using var hmac = new HMACSHA512();
            builder.HasData(
                new Clientes()
                {
                    Id = 1,
                    Name = "Super",
                    LastName = "Admin",
                    Username = "admin",
                    Address = "Av Candiles 315 169",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin1234")),
                    PasswordSalt = hmac.Key,
                    Rol = ERol.ADMIN
                });

        }
    }
}
