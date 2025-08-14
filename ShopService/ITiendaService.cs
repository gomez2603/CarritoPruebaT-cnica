using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopService
{
    public interface ITiendaService
    {
        Tiendas Get(int id);

        IQueryable<Tiendas> GetAll(
            Expression<Func<Tiendas, bool>> filter = null,
            string incluirPropiedades = ""
            );

        Tiendas FindOne(
             Expression<Func<Tiendas, bool>> filter = null,
             string incluirPropiedades = ""
             );

        void Add(Tiendas entidad);
        void Update(Tiendas entidad);

        void Remove(int id);

        void Remove(Tiendas entidad);

        void RemoveRange(IEnumerable<Tiendas> entidad);
    }
}
