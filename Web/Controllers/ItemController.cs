using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    using Application.Dtos;
    using Application.Dtos.Item;
    using Application.Interfaces;
    using Domain.Core.Bus;
    using Domain.Core.Notifications;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class ItemController: ApiController
    {

        private readonly IItemService _itemService;
        public ItemController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IItemService itemService) : base(notifications, mediator)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_itemService.GetAll());
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search([FromBody]SearchItemDto model)
        {
            var result = _itemService.Search(model);
            return Response(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddItemDto model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _itemService.Add(model);

            return Response(model);
        }
    }
}
