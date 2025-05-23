﻿using AutoMapper;
using MediatR;
using SwiftShop.Order.Application.Features.Commands.OrderingCommands;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _orderingRepository;
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var updatingValue = _mapper.Map<Ordering>(request);
            await _orderingRepository.UpdateAsync(updatingValue);
        }
    }
}
