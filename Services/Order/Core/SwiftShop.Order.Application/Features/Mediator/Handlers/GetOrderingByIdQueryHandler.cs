using AutoMapper;
using MediatR;
using SwiftShop.Order.Application.Features.Mediator.Queries;
using SwiftShop.Order.Application.Features.Mediator.Results;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Mediator.Handlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _orderingRepository;
        private readonly IMapper _mapper;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var ordering = await _orderingRepository.GetByIdAsync(request.OrderingId);
            return _mapper.Map<GetOrderingByIdQueryResult>(ordering);
        }
    }
}
