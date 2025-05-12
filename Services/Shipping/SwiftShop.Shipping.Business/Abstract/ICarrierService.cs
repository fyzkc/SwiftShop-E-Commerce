using SwiftShop.Shipping.DataAccess.Repositories;
using SwiftShop.Shipping.Dto.Dtos.Carrier;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Abstract
{
    public interface ICarrierService : IGenericService<Carrier,CreateCarrierDto,UpdateCarrierDto,ListCarrierDto>
    {
    }
}
