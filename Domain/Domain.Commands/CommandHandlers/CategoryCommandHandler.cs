using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands.Commands;
using Domain.Commands.Interfaces;
using Domain.Commands.Models;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;

namespace Domain.Commands.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<AddNewCategoryCommand>,
        IRequestHandler<RemoveCategoryCommand>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFieldTypeRepository _categoryFieldTypeRepository;
        private readonly IMediatorHandler _bus;


        public CategoryCommandHandler(
                              ICategoryRepository categoryRepository,
                              ICategoryFieldTypeRepository categoryFieldTypeRepository,
                              IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications)
                              : base(uow, bus, notifications)
        {
            _categoryFieldTypeRepository = categoryFieldTypeRepository;
            _categoryRepository = categoryRepository;
            _bus = bus;
        }


        public Task Handle(AddNewCategoryCommand request,
         CancellationToken cancellationToken)
        {
            var category = new Category();
            category.Name = request.Name;
            category.Description = request.Description;

            #region Add CategoryFields 

            var categoryFields = new List<CategoryField>();
            for (var i = 0; i < request.CategoryFieldNames.Count; i++)
            {
                var categoryFieldType = _categoryFieldTypeRepository.GetByCode(request.CategoryFieldTypes[i]);
                var categoryField = new CategoryField
                {
                    Name = request.CategoryFieldNames[i],
                    CategoryFieldType = categoryFieldType,
                    Description = "test"
                };
                categoryFields.Add(categoryField);
            }
            category.CategoryFields = categoryFields;

            #endregion

            _categoryRepository.Add(category);

            Commit();

            return Task.CompletedTask;
        }

        public Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(request.Id);

            if (category == null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, 
                "Category not found in the system."));
                return Task.CompletedTask;
            }

            _categoryRepository.Remove(request.Id);

            Commit();
            return Task.CompletedTask;
        }
    }
}
