using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IArticulosRepository ArticulosRepository { get; }
        IArtTiendaRepository ArttiendaRepository { get; }
        IClientRepository ClientRepository { get; }
        ISalesRepository SalesRepository { get; }
        ITiendaRepository TiendaRepository { get; }

        void Save();
    }
}
