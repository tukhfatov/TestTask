using Application.Dtos;
using AutoMapper;
using Domain.Commands.Models;

namespace Application.Automapper
{
    using Dtos.Item;

    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, AddCategoryDto>();
            CreateMap<CategoryField, CategoryFieldDto>()
                .ForMember(dest => dest.TypeCode, o => o.MapFrom(k => k.CategoryFieldType.Code))
                .ForMember(dest => dest.TypeName, o => o.MapFrom(k => k.CategoryFieldType.Name));
            CreateMap<Category, ViewCategoryDto>()
                .ForMember(x=>x.CategoryFields, c=>c.MapFrom(k=>k.CategoryFields));

            CreateMap<ItemValue, ItemValueDto>()
                .ForMember(dest => dest.FieldDto, o => o.MapFrom(x=>x.Field));
            CreateMap<Item, ViewItemDto>()
                .ForMember(d => d.CategoryId, o => o.MapFrom(x => x.Category.Id));
        }
    }        

}