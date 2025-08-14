using ShopDomain;
using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Implementation
{
    public class ClientRepository :BaseRepository<Clientes>,IClientRepository
    {
        private readonly ShopContext _context;
        public ClientRepository(ShopContext context):base(context) 
        {
            _context = context;
            
        }




        public void Update(Clientes clientes)
        {
            var entity = _context.clientes.FirstOrDefault(x=>x.Id == clientes.Id);
            if (entity != null)
            {
                entity.Address = clientes.Address;
                entity.Name = clientes.Name;
                entity.LastName = clientes.LastName;
                _context.clientes.Update(entity);
            }

        }
    }
}
