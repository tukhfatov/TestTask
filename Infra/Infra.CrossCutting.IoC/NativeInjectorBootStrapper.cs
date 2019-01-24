using Application.Interfaces;
using Application.Services;
using Domain.Commands.CommandHandlers;
using Domain.Commands.Commands;
using Domain.Commands.Interfaces;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Infra.CrossCutting.Bus;
using Infra.Data.Context;
using Infra.Data.Repository;
using Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
//            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICategoryService, CategoryService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
//            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
//            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
//            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewCategoryCommand>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand>, CategoryCommandHandler>();
            //            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            //            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryFieldTypeRepository, CategoryFieldTypeRepository>();
            services.AddScoped<ICategoryFieldRepository, CategoryFieldRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TestTaskDbContext>();

            // Infra - Data EventSourcing
//            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
//            services.AddScoped<IEventStore, SqlEventStore>();
//            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
//            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
//            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
//            services.AddScoped<IUser, AspNetUser>();
        }
    }
}