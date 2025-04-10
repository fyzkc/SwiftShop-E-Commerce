using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SwiftShop.IdentityServer
{
    public static class Config
    {
        //this class contains the authorization roles of the clients. 
        //also contains configuration for API resources, scopes, and identity resources used in authorization.

        //ApiResources, tells IdentityServer which APIs are exists. 
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            //An API resource named CatalogResource is defined here.
            //And 2 scopes (which means permissions) defined for this API.

            new ApiResource("CatalogResource"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            //Catalog microservice needs comprehensive management.
            //CatalogFullPermission is for admin users.
            //CatalogReadPermission is for users that only make listing operations. 

            new ApiResource("DiscountResource"){Scopes={ "DiscountFullPermission","DiscountReadPermission"}},
            //Discount microservice should have more limited access.
            //DiscountFullPermission is for admin or campaign manager users.
            //DiscountReadPermission is for users that only sees the coupons.

            new ApiResource("OrderResource"){Scopes={"OrderFullPermission","OrderReadPermission"}},
            //Order microservice is generally user-oriented.
            //OrderFullPermission is for making an order, managing addresses kind of operations. 
            //OrderReadPermission is for like the operation of seeing the orders history.

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        //The IdentityResources property defines what information (claims) about the user are accessible.
        //OpenId is the heart of authentication. It returns the user id (sub).
        //Email, returns the user email.
        //Profile, returns the general information about the user such as name, surname etc.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(), //this IdentityResources is not what we named of our enum list.
            //This is a class and it has another classes such as OpenId, Email, Phone, Address and Profile in it which are inherits from IdentityResource class.
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        //ApiScope defines which permissions will be granted to applications.
        //CatalogFullPermission: For all the operations about the Catalog (CRUD)
        //CatalogReadPermission: Only for reading operations.
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full access to Catalog service"),
            new ApiScope("CatalogReadPermission","Read-only access to Catalog service"),


            new ApiScope("DiscountFullPermission","Full access to Discount service"),
            new ApiScope("DiscountReadPermission","Read-only access to Discount service"),


            new ApiScope("OrderFullPermission","Full access to Order service"),
            new ApiScope("OrderReadPermission","Read-only access to Order service"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor and Manager clients has more limited and more basic user operations. 
            //So they don't need the authentication informations directly. That's why we don't define IdentityServerContants for them.

            //Visitor Client
            //only access to the public APIs, not to the IdentityServer's own APIs.
            new Client
            {
                ClientId="VisitorId",
                ClientName = "Swift Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials, //this token is using for only for these client types, not for a spesific login process.
                ClientSecrets={new Secret("swiftshopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "OrderFullPermission","DiscountReadPermission" }
                //AccessTokenLifetime is 1 hour as default.
            },

            //Manager Client
            new Client
            {
                ClientId="ManagerId",
                ClientName="Swift Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("swiftshopsecret".Sha256())},
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderReadPermission" }
            },

            //Admin Client
            new Client
            {
                ClientId="AdminId",
                ClientName="Swift Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("swiftshopsecret".Sha256())},
                AllowedScopes={ 
                    "CatalogFullPermission", 
                    "DiscountFullPermission", 
                    "OrderFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName, //this constant defines the IdentityServer's own API.
                    IdentityServerConstants.StandardScopes.Email, //these scopes are necessary for taking the user informations via OpenID.
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=1800
            }

        };

    }
}