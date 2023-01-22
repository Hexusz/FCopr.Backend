using System;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCopr.Application.Orders.Queries.GetOrderListForDate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCorp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class forDateController : BaseController
    {
        private readonly IMapper _mapper;

        public forDateController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of orders made today
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /forDate
        /// </remarks>
        /// <returns>Returns OrderListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQueryForDate
            {
                Date = DateTime.Today
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}