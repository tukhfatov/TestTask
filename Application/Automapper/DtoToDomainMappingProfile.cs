using System.Linq;
using Application.Dtos;
using AutoMapper;
using Domain.Commands.Commands;
using Domain.Commands.Models;

namespace Application.Automapper
{
    using Domain.Commands.Commands.Item;
    using Dtos.Item;

    public class DtoToDomainMappingProfile: Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AddCategoryDto, AddNewCategoryCommand>()
                    .ConstructUsing(c => new AddNewCategoryCommand(
                                c.Name,
                                c.Description,
                                c.CategoryFieldNames,
                                c.CategoryFieldTypes
                                ));

            CreateMap<AddItemDto, AddNewItemCommand>()
                .ConstructUsing(c => new AddNewItemCommand(
                    c.Name,
                    c.Description,
                    c.Price,
                    c.Category,
                    c.CategoryFieldIds,
                    c.CategoryValues
                ));
        }
    }
}