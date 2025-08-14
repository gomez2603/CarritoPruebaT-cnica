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
    public class SalesService : ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Sales entidad)
        {
            _unitOfWork.SalesRepository.Add(entidad);
            _unitOfWork.Save();
        }

        public void Update(Sales entidad)
        {
            _unitOfWork.SalesRepository.Update(entidad);
            _unitOfWork.Save();
        }

        public Sales FindOne(Expression<Func<Sales, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.SalesRepository.FindOne(filter, incluirPropiedades);
        }

        public Sales Get(int id)
        {
            return _unitOfWork.SalesRepository.Get(id);
        }

        public IQueryable<Sales> GetAll(Expression<Func<Sales, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.SalesRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.SalesRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Sales entidad)
        {
            _unitOfWork.SalesRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Sales> entidad)
        {
            _unitOfWork.SalesRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
