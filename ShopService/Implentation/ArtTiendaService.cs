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
    public class ArtTiendaService : IArtTiendaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtTiendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ArtTienda entidad)
        {
            _unitOfWork.ArttiendaRepository.Add(entidad);
            _unitOfWork.Save();
        }
        public void Update(ArtTienda entidad)
        {
            _unitOfWork.ArttiendaRepository.Update(entidad);
            _unitOfWork.Save();
        }
        public ArtTienda FindOne(Expression<Func<ArtTienda, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.ArttiendaRepository.FindOne(filter, incluirPropiedades);
        }

        public ArtTienda Get(int id)
        {
            return _unitOfWork.ArttiendaRepository.Get(id);
        }

        public IQueryable<ArtTienda> GetAll(Expression<Func<ArtTienda, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.ArttiendaRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.ArttiendaRepository.Remove(id);
        }

        public void Remove(ArtTienda entidad)
        {
            _unitOfWork.ArttiendaRepository.Remove(entidad);
        }

        public void RemoveRange(IEnumerable<ArtTienda> entidad)
        {
            _unitOfWork.ArttiendaRepository.RemoveRange(entidad);
        }
    }
}
