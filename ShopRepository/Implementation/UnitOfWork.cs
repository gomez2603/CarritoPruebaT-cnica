using ShopDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;
        public IArticulosRepository ArticulosRepository { get;  private set; }

        public IArtTiendaRepository ArttiendaRepository { get; private set; }


        public IClientRepository ClientRepository { get; private set; }

        public ISalesRepository SalesRepository  { get; private set; }


        public ITiendaRepository TiendaRepository { get; private set; }

        public UnitOfWork(ShopContext context)
        {
            _context = context;
            ArticulosRepository = new ArticuloRepository(context);
            ArttiendaRepository = new ArtTiendaRepository(context);
            ClientRepository = new ClientRepository(context);   
            SalesRepository = new SalesRepository(context);
            TiendaRepository = new TiendaRepository(context);
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
          _context.SaveChanges();
        }
    }
}
