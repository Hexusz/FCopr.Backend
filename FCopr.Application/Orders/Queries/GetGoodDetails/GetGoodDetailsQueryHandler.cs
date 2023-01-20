using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FCopr.Application.Common.Exceptions;
using FCopr.Application.Interfaces;
using FCopr.Application.Orders.Queries.GetOrderDetails;
using FCorp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FCopr.Application.Orders.Queries.GetGoodDetails
{
    public class GetGoodDetailsQueryHandler : IRequestHandler<GetGoodDetailsQuery, GoodDetailsVm>
    {
        private readonly IFCorpDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGoodDetailsQueryHandler(IFCorpDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GoodDetailsVm> Handle(GetGoodDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Goods
                .FirstOrDefaultAsync(Good =>
                    Good.Articul == request.Articul, cancellationToken);

            if (entity == null || entity.Articul != request.Articul)
            {
                throw new NotFoundException(nameof(Good), request.Articul);
            }

            return _mapper.Map<GoodDetailsVm>(entity);
        }
    }
}
