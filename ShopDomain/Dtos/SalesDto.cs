using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Dtos
{
    public class SalesDto
    {
        public int SaleId { get; set; }
        public int ArticuloId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
