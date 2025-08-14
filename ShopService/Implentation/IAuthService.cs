using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopService.Implentation
{
    public interface IAuthService
    {
        string CreateToken(Clientes user);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPassword(string Password, byte[] passwordHash, byte[] passwordSalt);
    }
}
