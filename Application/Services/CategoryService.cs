using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Commands.Commands;
using Domain.Commands.Interfaces;
using Domain.Core.Bus;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper,
                          IMediatorHandler bus,
                          ICategoryRepository categoryRepository
                          )
        {
            _mapper = mapper;
            _bus = bus;
            _categoryRepository = categoryRepository;
        }


        public void Add(CategoryDto category)
        {
            var addCommand = _mapper.Map<AddNewCategoryCommand>(category);
            _bus.SendCommand(addCommand);
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryDto>();
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            _bus.SendCommand(removeCommand);
        }
    }
}
