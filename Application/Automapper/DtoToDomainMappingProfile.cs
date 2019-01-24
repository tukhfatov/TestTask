using System.Linq;
using Application.Dtos;
using AutoMapper;
using Domain.Commands.Commands;
using Domain.Commands.Models;

namespace Application.Automapper
{
    public class DtoToDomainMappingProfile: Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CategoryDto, AddNewCategoryCommand>()
                    .ConstructUsing(c => new AddNewCategoryCommand(
                                c.Name,
                                c.Description,
                                c.CategoryFieldNames,
                                c.CategoryFieldTypes
                                ));
        }
    }
}