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
    public class ArticuloService:IArticuloService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticuloService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Articulo entidad)
        {
            _unitOfWork.ArticulosRepository.Add(entidad);
            _unitOfWork.Save();
        }
        public void Update(Articulo entidad)
        {
            _unitOfWork.ArticulosRepository.Update(entidad);
            _unitOfWork.Save();
        }

        public Articulo FindOne(Expression<Func<Articulo, bool>> filter = null, string incluirPropiedades = "")
        {
           return    _unitOfWork.ArticulosRepository.FindOne(filter, incluirPropiedades);  
        }

        public Articulo Get(int id)
        {
         return _unitOfWork.ArticulosRepository.Get(id);
        }

        public IQueryable<Articulo> GetAll(Expression<Func<Articulo, bool>> filter = null, string incluirPropiedades = "")
        {
          return _unitOfWork.ArticulosRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
           _unitOfWork.ArticulosRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Articulo entidad)
        {
            _unitOfWork.ArticulosRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Articulo> entidad)
        {
            _unitOfWork.ArticulosRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
