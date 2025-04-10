using Microsoft.AspNetCore.Identity;

namespace SwiftShop.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
        //because of this class inherits IdentityUser class, it already has UserName and Email properties.
        //in this class we added the Name and Surname properties.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
