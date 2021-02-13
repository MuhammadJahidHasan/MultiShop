using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, Product>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}