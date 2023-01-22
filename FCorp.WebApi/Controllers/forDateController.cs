using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Orders.Queries.GetOrderList;
using FCopr.Application.Orders.Queries.GetOrderListForDate;
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