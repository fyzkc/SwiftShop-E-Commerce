using AutoMapper;
using SwiftShop.Shipping.Dto.Dtos.Carrier;
using SwiftShop.Shipping.Dto.Dtos.Company;
using SwiftShop.Shipping.Dto.Dtos.Shipment;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Dto.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Carrier, CreateCarrierDto>().ReverseMap();
            CreateMap<Carrier, UpdateCarrierDto>().ReverseMap();
            CreateMap<Carrier, ListCarrierDto>().ReverseMap();

            CreateMap<Company,CreateCompanyDto>().ReverseMap();
            CreateMap<Company,UpdateCompanyDto>().ReverseMap();
            CreateMap<Company,ListCompanyDto>().ReverseMap();

            CreateMap<Shipment, CreateShipmentDto>().ReverseMap();
            CreateMap<Shipment, UpdateShipmentDto>().ReverseMap();
            CreateMap<Shipment, ListShipmentDto>().ReverseMap();
        }
    }
}
