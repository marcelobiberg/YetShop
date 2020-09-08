using AutoMapper;
using Yet.API.CatalogoItemEndpoints;
using Yet.API.CatalogoMarcaEndpoints;
using Yet.API.CatalogoTipoEndpoints;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogoItem, CatalogoItemDto>();
            CreateMap<CatalogoTipo, CatalogoTipoDto>()
                .ForMember(dto => dto.Nome, options => options.MapFrom(src => src.Tipo));
            CreateMap<CatalogoMarca, CatalogoMarcaDto>()
                .ForMember(dto => dto.Nome, options => options.MapFrom(src => src.Marca));
        }
    }
}
