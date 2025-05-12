using SwiftShop.Shipping.Dto.Dtos.Company;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Abstract
{
    public interface ICompanyService :  IGenericService<Company,CreateCompanyDto,UpdateCompanyDto,ListCompanyDto>
    {
    }
}