using AutoMapper;
using SwiftShop.IdentityServer.Dtos;
using SwiftShop.IdentityServer.Models;

namespace SwiftShop.IdentityServer.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<UserRegisterDto, ApplicationUser>().ReverseMap();
        }        
    }
}
