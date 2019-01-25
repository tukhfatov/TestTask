using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
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
    }
}
