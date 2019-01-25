using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Commands.Item;
    using Core.Bus;
    using Core.Notifications;
    using Interfaces;
    using MediatR;
    using Models;

    public class ItemCommandHandler: CommandHandler,
            IRequestHandler<AddNewItemCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFieldRepository _categoryFieldRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMediatorHandler _bus;


        public ItemCommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IItemRepository itemRepository,
            ICategoryRepository categoryRepository,
            ICategoryFieldRepository categoryFieldRepository)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _categoryFieldRepository = categoryFieldRepository;
        }

        public Task Handle(AddNewItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item();
            item.Name = request.Name;
            item.Description = request.Description;
            item.Price = request.Price;

            var category = _categoryRepository.GetById(request.CategoryId);
            item.Category = category;

            var itemValues = new List<ItemValue>();
            for (var i = 0; i < request.CategoryFieldIds.Count; i++)
            {
                var categoryField = _categoryFieldRepository.GetById(request.CategoryFieldIds[i]);
                itemValues.Add(new ItemValue
                {
                    Field = categoryField,
                    FieldValue = request.FieldValues[i]
                });

            }
            item.ItemValues = itemValues;

            _itemRepository.Add(item);
            Commit();

            return Task.CompletedTask;
        }
    }
}
