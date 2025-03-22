using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery //if there is any parameter on "read processes", it is defining on queries folder.

        //queries classes includes the parameters to make a query. 
    {
        public int AddressId { get; set; }
        public GetAddressByIdQuery(int addressId) //the id parameter will be taken by the constructor.
        {
            AddressId = addressId;
        }
    }
}
