using AutoMapper;
using NFeApi.Dtos;
using NFeApi.Entities;

namespace NFeApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NFe, NFeDto>().ReverseMap()
                .ForMember(dest => dest.Emitente, opt => opt.MapFrom(src => src.Emitente))
                .ForMember(dest => dest.ItensNFe, opt => opt.MapFrom(src => src.ItensNFe));

            CreateMap<Emitente, EmitenteDto>().ReverseMap();

            CreateMap<ItemNFe, ItemNFeDto>().ReverseMap();
        }
    }
}
