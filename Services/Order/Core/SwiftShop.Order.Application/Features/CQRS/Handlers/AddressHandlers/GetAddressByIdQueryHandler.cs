using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Queries.AddressQueries;
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
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query) //this method takes and parameter as GetAddressByIdQuery type and return a GetAddressByIdQueryResult type value. 
        {
            var adress = await _repository.GetByIdAsync(query.AddressId);
            //GetByIdAsync method is defined as Task<T> GetByIdAsync(int id); and in this field the T value is Address. 
            //so that GetByIdAsync method has a Address type and also address variable too. 
            return _mapper.Map<GetAddressByIdQueryResult>(adress); //for returning the GetAddressByIdQueryResult type value, we should turn the Address type variable into the GetAddressByIdQueryResult type. 
        }
    }
}
