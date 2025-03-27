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
    //the requested class which had the parameter or smth is GetOrderingQuery. Query classes always the requested classes for Read processes.
    //and the response class is GetOrderingQueryResult as a List format. Result classes always the response classes for the read processes. 
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _orderingRepository;
        private readonly IMapper _mapper;

        public GetOrderingQueryHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var orderings = await _orderingRepository.GetAllAsync();
            return _mapper.Map<List<GetOrderingQueryResult>>(orderings);
        }
    }
}
