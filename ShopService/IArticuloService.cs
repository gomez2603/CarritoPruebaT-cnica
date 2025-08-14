using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopService
{
    public interface IArticuloService
    {
       Articulo Get(int id);

        IQueryable<Articulo> GetAll(
            Expression<Func<Articulo, bool>> filter = null,
            string incluirPropiedades = ""
            );

       Articulo FindOne(
            Expression<Func<Articulo, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(Articulo entidad);
        void Update(Articulo entidad);

        void Remove(int id);

        void Remove(Articulo entidad);

        void RemoveRange(IEnumerable<Articulo> entidad);
    }
}
