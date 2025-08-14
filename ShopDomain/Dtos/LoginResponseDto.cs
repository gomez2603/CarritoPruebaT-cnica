using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Dtos
{
    public class LoginResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
