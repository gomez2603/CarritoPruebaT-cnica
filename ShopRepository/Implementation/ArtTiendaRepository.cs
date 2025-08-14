using ShopDomain;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class ArtTiendaRepository :BaseRepository<ArtTienda> , IArtTiendaRepository
    {
        private readonly ShopContext _context;

        public ArtTiendaRepository(ShopContext context) : base(context) 
        {
            _context = context;
        }

       public void Update(ArtTienda artTienda)
        {
            var entity = _context.artTiendas.FirstOrDefault(x=>x.Id == artTienda.Id);
            if (entity != null) { 
                entity.ArticuloId = artTienda.ArticuloId;
                entity.Fecha = DateTime.Now;
                entity.StoreId = artTienda.StoreId;
                _context.artTiendas.Update(entity);
            
            }
        }
    }
}
