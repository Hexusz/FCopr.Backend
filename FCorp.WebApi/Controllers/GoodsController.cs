using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCopr.Application.FCorp.Commands.DeleteOrder;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCorp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : BaseController
    {
        private readonly IMapper _mapper;

        public GoodsController(IMapper mapper) => _mapper = mapper;

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
    }
}