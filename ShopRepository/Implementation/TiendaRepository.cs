using ShopDomain;
using ShopDomain.Dtos;
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

        public List<ArticuloDto> GetArticulosPorTienda(int storeId)
        {
            return _context.artTiendas
        .Where(at => at.StoreId == storeId)
        .Select(at => new ArticuloDto
        {
            Id = at.Articulo.Id,
            Code = at.Articulo.Code,
            Description = at.Articulo.Description,
            Price = at.Articulo.Price,
            Image = at.Articulo.Image   
        })
        .ToList();
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
