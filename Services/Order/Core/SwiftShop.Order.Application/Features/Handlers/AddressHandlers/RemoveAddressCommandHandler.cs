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
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommand>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public RemoveAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var deletingValue = await _addressRepository.GetByIdAsync(request.AddressId);
            await _addressRepository.DeleteAsync(deletingValue);
        }
    }
}
