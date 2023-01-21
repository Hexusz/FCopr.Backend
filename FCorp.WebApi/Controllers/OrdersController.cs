using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCopr.Application.FCorp.Commands.DeleteOrder;
using FCopr.Application.FCorp.Commands.UpdateOrder;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCorp.Domain;
using FCorp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : BaseController
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsVm>> Get(ushort id)
        {
            var query = new GetOrderDetailsQuery
            {
                OrderId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<ushort>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            command.ClientFullName = createOrderDto.ClientFullName;
            command.Positions = createOrderDto.Positions;
            command.Status = createOrderDto.Status;
            command.Positions = new List<OrderPositions>()
            {
                new OrderPositions(){OrderId = command.OrderId, GoodId = 1},
                new OrderPositions(){OrderId = command.OrderId, GoodId = 2}
            };
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ushort id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            command.OrderId = id;
            command.ClientFullName = updateOrderDto.ClientFullName;
            command.Positions = updateOrderDto.Positions;
            command.Status = updateOrderDto.Status;
            var orderI = await Mediator.Send(command);
            return Ok(orderI);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ushort id)
        {
            var command = new DeleteOrderCommand
            {
                OrderId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}