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
    public class TiendaService :ITiendaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TiendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Tiendas entidad)
        {
            _unitOfWork.TiendaRepository.Add(entidad);
            _unitOfWork.Save();
        }
        public void Update(Tiendas entidad)
        {
            _unitOfWork.TiendaRepository.Update(entidad);
            _unitOfWork.Save();
        }
        public Tiendas FindOne(Expression<Func<Tiendas, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.TiendaRepository.FindOne(filter, incluirPropiedades);
        }

        public Tiendas Get(int id)
        {
            return _unitOfWork.TiendaRepository.Get(id);
        }

        public IQueryable<Tiendas> GetAll(Expression<Func<Tiendas, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.TiendaRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.TiendaRepository.Remove(id);
        }

        public void Remove(Tiendas entidad)
        {
            _unitOfWork.TiendaRepository.Remove(entidad);
        }

        public void RemoveRange(IEnumerable<Tiendas> entidad)
        {
            _unitOfWork.TiendaRepository.RemoveRange(entidad);
        }
    }
}
