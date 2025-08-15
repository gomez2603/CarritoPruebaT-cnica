using ShopDomain;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class ArticuloRepository : BaseRepository<Articulo>, IArticulosRepository
    {
        private readonly ShopContext _context;

        public ArticuloRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Articulo articulo)
        {
            var entity = _context.articulos.FirstOrDefault(x => x.Id == articulo.Id);
            if (entity != null)
            {
                entity.Code = articulo.Code;
                entity.Description = articulo.Description;
                entity.Price = articulo.Price;
                if(articulo.Image != null)
                {
                    entity.Image = articulo.Image;
                } 
             
                entity.Stock = articulo.Stock;
            }
        }
    }

}