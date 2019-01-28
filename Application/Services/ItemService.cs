using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Commands.Commands;
    using Domain.Commands.Commands.Item;
    using Domain.Commands.Interfaces;
    using Domain.Core.Bus;
    using Dtos;
    using Dtos.Item;
    using Interfaces;
    public class ItemService: IItemService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        private readonly IItemRepository _itemRepository;
        
        public ItemService(IMapper mapper,
            IMediatorHandler bus, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _itemRepository = itemRepository;
        }

        public void Add(AddItemDto item)
        {
            var addCommand = _mapper.Map<AddNewItemCommand>(item);
            _bus.SendCommand(addCommand);
        }

        public IEnumerable<ViewItemDto> GetAll()
        {
            return _itemRepository.GetAll().ProjectTo<ViewItemDto>();
        }

        public IEnumerable<ViewItemDto> Search(SearchItemDto query)
        {
            var result = _itemRepository.GetAllAsNoTracking();
            if (query.CategoryId == 0)
            {
                return result.ProjectTo<ViewItemDto>();
            }
            result = result.Where(x => x.Category.Id==query.CategoryId);

            foreach (var field in query.Fields)
            {
                if (!string.IsNullOrEmpty(field.FieldQuery))
                {
                    result = result.Where(x =>
                    x.ItemValues.Any(
                        j => j.FieldValue.ToLower().StartsWith(field.FieldQuery.ToLower()) && j.Field.Id==field.FieldId));
                }
            }
            return result.ProjectTo<ViewItemDto>().ToList();
        }
    }
}
