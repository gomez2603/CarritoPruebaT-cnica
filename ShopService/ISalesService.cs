using ShopDomain.Dtos;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopService
{
    public interface ISalesService
    {
        Sales Get(int id);

        IQueryable<Sales> GetAll(
            Expression<Func<Sales, bool>> filter = null,
            string incluirPropiedades = ""
            );

        Sales FindOne(
             Expression<Func<Sales, bool>> filter = null,
             string incluirPropiedades = ""
             );
        List<SalesDto> GetSalesByClient(int clientId);
        void Add(Sales entidad);
        
        void Update(Sales entidad);

        void Remove(int id);

        void Remove(Sales entidad);

        void RemoveRange(IEnumerable<Sales> entidad);
    }
}
