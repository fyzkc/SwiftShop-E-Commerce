using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            var orderDetail = _mapper.Map<OrderDetail>(createOrderDetailCommand);
            await _repository.CreateAsync(orderDetail);
        }
    }
}
