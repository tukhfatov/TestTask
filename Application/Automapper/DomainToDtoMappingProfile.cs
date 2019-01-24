using Application.Dtos;
using AutoMapper;
using Domain.Commands.Models;

namespace Application.Automapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }        

}