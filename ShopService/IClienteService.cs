using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopService
{
    public interface IClienteService
    {
        Clientes Get(int id);

        IQueryable<Clientes> GetAll(
            Expression<Func<Clientes, bool>> filter = null,
            string incluirPropiedades = ""
            );

        Clientes FindOne(
             Expression<Func<Clientes, bool>> filter = null,
             string incluirPropiedades = ""
             );

        void Add(Clientes entidad);
        void Update(Clientes entidad);

        void Remove(int id);

        void Remove(Clientes entidad);

        void RemoveRange(IEnumerable<Clientes> entidad);
    }
}
