using AutoMapper;
using SwiftShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using SwiftShop.Order.Application.Features.CQRS.Results.AddressResults;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.MappingProfiles
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<CreateAddressCommand, Address>(); //we are turning the CreateAddressCommand class into the Address entity for creation processes. 
            CreateMap<UpdateAddressCommand, Address>(); //we are turning the UpdateAddressCommand class into the Address entity for updating processes. 
            CreateMap<Address, GetAddressQueryResult>(); //we are turning the Address entity into the GetAddressQueryResult class for resulting processes. 
            CreateMap<Address, GetAddressByIdQueryResult>(); //we are turning the Address entity into the GetAddressByIdQueryResult class for resulting processes. 
        }
    }
}
