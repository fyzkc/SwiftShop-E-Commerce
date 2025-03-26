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
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var orderDetail = await _repository.GetByIdAsync(removeOrderDetailCommand.OrderDetailId);
            await _repository.DeleteAsync(orderDetail);
        }
    }
}
