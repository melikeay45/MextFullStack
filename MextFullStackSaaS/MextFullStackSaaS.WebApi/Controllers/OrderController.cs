﻿using MediatR;
using MextFullStactSaaS.Application.Features.Orders.Commands.Add;
using MextFullStactSaaS.Application.Features.Orders.Commands.Delete;
using MextFullStactSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullStactSaaS.Application.Features.Orders.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStackSaaS.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediatr;

        public OrdersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderGetByIdQuery(id), cancellationToken));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderDeleteCommand(id), cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderAddCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderGetAllQuery(), cancellationToken));
        }
    }
}
