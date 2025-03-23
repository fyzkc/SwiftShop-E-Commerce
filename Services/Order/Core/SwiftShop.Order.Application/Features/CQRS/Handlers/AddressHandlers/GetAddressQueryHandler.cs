using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Results.AddressResults;
using SwiftShop.Order.Application.Interfaces;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var addresses = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAddressQueryResult>>(addresses);
        }
    }
}
