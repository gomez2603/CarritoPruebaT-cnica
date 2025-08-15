using AutoMapper;
using ShopDomain.Entities;


namespace ShopDomain.Dtos
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<CreateUpdateArticulo, Articulo>();
            CreateMap<Clientes, userResponseDto>();
            CreateMap<Clientes,LoginResponseDto>();
            CreateMap<RegisterDto, Clientes>();
            CreateMap<ArtTienda,ArtTIendaResponse>();
        }
    }
}
