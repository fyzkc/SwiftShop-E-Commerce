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
    public class CreateAddressCommandHandler //handlers folder is for crud processes.
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            var address = _mapper.Map<Address>(createAddressCommand); //we took the address object as CreateAddressCommand type, then mapped it to the actual Address entity to create a new address later.
            await _repository.CreateAsync(address); //we took the Address type variable and use it for CreateAsync() method.
            //The content of this method will be defined later in API project's service classes and then will be used in Controllers. 
        }
    }
}
