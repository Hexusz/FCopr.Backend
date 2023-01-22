using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FCopr.Application.FCorp.Commands.DeleteOrder;
using FCopr.Application.Orders.Queries.GetGoodDetails;
using FCopr.Application.Orders.Queries.GetGoodList;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCorp.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : BaseController
    {
        private readonly IMapper _mapper;

        public GoodsController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of goods
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /goods
        /// </remarks>
        /// <returns>Returns GoodListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GoodListVm>> GetAll()
        {
            var query = new GetGoodListQuery
            {
                
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the good by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /goods/1
        /// </remarks>
        /// <param name="id">Good id (ushort)</param>
        /// <returns>Returns GoodDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GoodDetailsVm>> Get(sbyte id)
        {
            var query = new GetGoodDetailsQuery
            {
                Articul = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}