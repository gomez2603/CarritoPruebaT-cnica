using ShopDomain;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class TiendaRepository : BaseRepository<Tiendas>, ITiendaRepository
    {
        private readonly ShopContext _context;
        public TiendaRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Tiendas tienda)
        {
            var entity = _context.tiendas.FirstOrDefault(x => x.Id == tienda.Id);
            if (entity != null)
            {
                entity.Address = tienda.Address;
                entity.Branch = tienda.Branch;
                _context.tiendas.Update(entity);
            }



        }
    }
}
