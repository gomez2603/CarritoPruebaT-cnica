using ShopDomain.Entities;
using System.Linq.Expressions;

namespace ShopService
{
    public interface IArtTiendaService
    {
        ArtTienda Get(int id);

        IQueryable<ArtTienda> GetAll(
            Expression<Func<ArtTienda, bool>> filter = null,
            string incluirPropiedades = ""
            );

        ArtTienda FindOne(
             Expression<Func<ArtTienda, bool>> filter = null,
             string incluirPropiedades = ""
             );

        void Add(ArtTienda entidad);

        void Update(ArtTienda entidad);
        void Remove(int id);

        void Remove(ArtTienda entidad);

        void RemoveRange(IEnumerable<ArtTienda> entidad);
    }
}
