using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using SwiftShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var orderDetail = await _repository.GetByIdAsync(getOrderDetailByIdQuery.OrderDetailId);
            return _mapper.Map<GetOrderDetailByIdQueryResult>(orderDetail);
        }
    }
}
