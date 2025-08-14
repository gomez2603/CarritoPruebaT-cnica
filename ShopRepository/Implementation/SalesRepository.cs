using ShopDomain;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class SalesRepository :BaseRepository<Sales>, ISalesRepository
    {
        private readonly ShopContext _context;

        public SalesRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Sales sales)
        {
            var entity = _context.sales.FirstOrDefault(x=>x.Id == sales.Id);
            if (entity != null) { 
            entity.ClientId = sales.ClientId;
            entity.ArticuloId = sales.ArticuloId;
            entity.Fecha = DateTime.Now;
            }
        }
    }
}
