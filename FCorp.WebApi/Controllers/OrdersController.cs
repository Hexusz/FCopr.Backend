﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCopr.Application.FCorp.Commands.DeleteOrder;
using FCopr.Application.FCorp.Commands.PartialUpdateOrder;
using FCopr.Application.FCorp.Commands.UpdateOrder;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCorp.Domain;
using FCorp.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : BaseController
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of orders in status: Registered
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /orders
        /// </remarks>
        /// <returns>Returns OrderListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery
            {

            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /orders/1
        /// </remarks>
        /// <param name="id">Order id (ushort)</param>
        /// <returns>Returns OrderDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDetailsVm>> Get(ushort id)
        {
            var query = new GetOrderDetailsQuery
            {
                OrderId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /orders
        ///{
        /// "Status":0,"ClientFullName":"asd","positions": [
        /// {
        /// "goodArticul": 1,
        /// "count": 1
        /// },{
        /// "goodArticul": 3,
        /// "count": 9
        /// }]
        /// }
        /// </remarks>
        /// <param name="createOrderDto">CreateOrderDto object</param>
        /// <returns>Returns Order id (ushort)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ushort>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            command.ClientFullName = createOrderDto.ClientFullName;
            command.Positions = createOrderDto.Positions;
            command.Status = createOrderDto.Status;
            command.Positions = createOrderDto.Positions;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /orders
        ///{
        /// "Status":0,"ClientFullName":"asd","positions": [
        /// {
        /// "goodArticul": 1,
        /// "count": 1
        /// },{
        /// "goodArticul": 3,
        /// "count": 9
        /// }]
        /// }
        /// </remarks>
        /// <param name="updateOrderDto">UpdateOrderDto object</param>
        /// <returns>Returns Order id (ushort)</returns>
        /// <response code="200">Success</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Partial update the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /orders
        ///{
        /// "Status":0,"ClientFullName":"asd","positions": [
        /// {
        /// "goodArticul": 1,
        /// "count": 1
        /// },{
        /// "goodArticul": 3,
        /// "count": 9
        /// }]
        /// }
        /// </remarks>
        /// <param name="partialUpdateOrderDto">PartialUpdateOrderDto object</param>
        /// <returns>Returns Order id (ushort)</returns>
        /// <response code="200">Success</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PartialUpdate(ushort id, [FromBody] PartialUpdateOrderDto partialUpdateOrderDto)
        {
            var command = _mapper.Map<PartialUpdateOrderCommand>(partialUpdateOrderDto);
            command.OrderId = id;
            command.ClientFullName = partialUpdateOrderDto.ClientFullName;
            command.Positions = partialUpdateOrderDto.Positions;
            command.Status = partialUpdateOrderDto.Status;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }

        /// <summary>
        /// Delete the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /orders/1
        /// </remarks>
        /// <param name="id">Order id (ushort)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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