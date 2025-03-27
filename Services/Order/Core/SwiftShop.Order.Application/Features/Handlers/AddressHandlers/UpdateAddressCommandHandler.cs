using AutoMapper;
using MediatR;
using SwiftShop.Order.Application.Features.Commands.AddressCommands;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var updatingValue = _mapper.Map<Address>(request);
            await _addressRepository.UpdateAsync(updatingValue);
        }
    }
}
