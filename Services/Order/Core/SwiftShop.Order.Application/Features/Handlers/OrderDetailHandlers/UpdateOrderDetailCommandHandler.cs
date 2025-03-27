using AutoMapper;
using MediatR;
using SwiftShop.Order.Application.Features.Commands.OrderDetailCommands;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var updatingValue = _mapper.Map<OrderDetail>(request);
            await _orderDetailRepository.UpdateAsync(updatingValue);
        }
    }
}
