using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public RemoveAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var removingValue = await _repository.GetByIdAsync(removeAddressCommand.AddressId);
            await _repository.DeleteAsync(removingValue);
        }
    }
}
