using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Dtos
{
    public class RegisterDto
    {
        public int? Id { get; set; } = 0;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int Rol { get; set; } = 1;
    }
}
