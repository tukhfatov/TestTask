using System;
using Application.Dtos;
using Application.Interfaces;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController: ApiController
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_categoryService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _categoryService.Add(model);

            return Response(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _categoryService.Remove(id);

            return Response();
        }

    }
}
