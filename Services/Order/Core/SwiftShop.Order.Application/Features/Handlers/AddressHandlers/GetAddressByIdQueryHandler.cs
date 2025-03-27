using AutoMapper;
using MediatR;
using SwiftShop.Order.Application.Features.Queries.AddressQueries;
using SwiftShop.Order.Application.Features.Results.AddressResults;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.AddressId);
            return _mapper.Map<GetAddressByIdQueryResult>(address);
        }
    }
}
