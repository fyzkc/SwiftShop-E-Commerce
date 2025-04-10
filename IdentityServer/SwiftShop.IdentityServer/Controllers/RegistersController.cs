using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.IdentityServer.Dtos;
using SwiftShop.IdentityServer.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace SwiftShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public RegistersController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = _mapper.Map<ApplicationUser>(userRegisterDto);
            //The properties (UserName, Email, Name, Surname) in UserRegisterDto and their equivalents in ApplicationUser are mapped.
            //Password does not mapped because it is not in ApplicationUser. AutoMapper sees this and ignores it and it does not give an error.
            //This implementation is for security. 
            //The Password field should only be in the UserRegisterDto class.
            //This Password property will be send to the CreateAsync method from UserManager class.
            //With that method, the normal password is converted into PasswordHash, which is hashed. 
            //And the hashed password will be save into the database. 

            if(!(userRegisterDto.Password.Length >= 6 &&
                Regex.IsMatch(userRegisterDto.Password, "[A-Z]") &&          // En az bir büyük harf
                Regex.IsMatch(userRegisterDto.Password, "[a-z]") &&          // En az bir küçük harf
                Regex.IsMatch(userRegisterDto.Password, "[^a-zA-Z0-9]"))
                )
            {
                return BadRequest("The password must be at least 6 characters, one upper, one lower case and special characters.");
            }
            var result = await _userManager.CreateAsync(values,userRegisterDto.Password);
            if (!result.Succeeded)
            {
                return Ok("Something went wrong");
            }
            return Ok("User registered successfully");
        }
    }
}
