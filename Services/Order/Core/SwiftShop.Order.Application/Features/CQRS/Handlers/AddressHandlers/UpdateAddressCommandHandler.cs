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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var address = _mapper.Map<Address>(updateAddressCommand);
            await _repository.UpdateAsync(address);
        }
    }
}
