using Microsoft.EntityFrameworkCore;
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

        public List<SalesDto> GetSalesByClient(int clientId)
        {
            return _context.sales
                .Where(s => s.ClientId == clientId)
                .Select(s => new SalesDto
                {
                    SaleId = s.Id,
                    ArticuloId = s.ArticuloId,
                    Code = s.Articulo.Code,
                    Description = s.Articulo.Description,
                    Price = s.Articulo.Price,
                    Image = s.Articulo.Image,
                    Fecha = s.Fecha
                })
                .ToList();
        }
    }
}
