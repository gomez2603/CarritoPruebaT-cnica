using ShopDomain.Entities;
using ShopRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopService.Implentation
{
    public class ClientesService :IClienteService 
    {

        private readonly IUnitOfWork _unitOfWork;
        public ClientesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Clientes entidad)
        {
            _unitOfWork.ClientRepository.Add(entidad);
            _unitOfWork.Save();
        }
        public void Update(Clientes entidad)
        {
            _unitOfWork.ClientRepository.Update(entidad);
            _unitOfWork.Save();
        }
        public Clientes FindOne(Expression<Func<Clientes, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.ClientRepository.FindOne(filter, incluirPropiedades);
        }

        public Clientes Get(int id)
        {
            return _unitOfWork.ClientRepository.Get(id);
        }

        public IQueryable<Clientes> GetAll(Expression<Func<Clientes, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.ClientRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.ClientRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Clientes entidad)
        {
            _unitOfWork.ClientRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Clientes> entidad)
        {
            _unitOfWork.ClientRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
