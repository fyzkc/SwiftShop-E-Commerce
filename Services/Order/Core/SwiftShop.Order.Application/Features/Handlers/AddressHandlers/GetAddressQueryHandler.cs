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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;
        public GetAddressQueryHandler(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<List<GetAddressQueryResult>>(addresses);
        }
    }
}
