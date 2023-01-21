using System;
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
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class forDateController : BaseController
    {
        private readonly IMapper _mapper;

        public forDateController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAll([FromBody] string date)
        {
            var query = new GetOrderListQueryForDate
            {
                Date = date
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}