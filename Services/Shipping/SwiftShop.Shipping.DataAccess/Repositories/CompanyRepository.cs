using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.DataAccess.Concrete;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.DataAccess.Repositories
{
    //it uses genericrepository for Company entity for base methods,
    //and also uses ICompanyRepository for future, if there will be any custom methods it should be able to use them too.
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        //for be able to use GenericRepsitory class, we should pass a DbContext parameter.
        //because the constructor method on GenericRepository class is taking a DbContext parameter. 

        //this constructor method takes a shippingContext parameter and sends them to the GenericRepository class.
        //because the base of CompanyRepository class is the class which it inherits. 
        public CompanyRepository(ShippingContext shippingContext) : base(shippingContext)
        {
            
        }
    }
}
