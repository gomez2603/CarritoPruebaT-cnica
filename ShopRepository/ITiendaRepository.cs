using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository
{
    public interface ITiendaRepository:IBaseRepository<Tiendas>
    {
        void Update(Tiendas tienda);
    }
}
