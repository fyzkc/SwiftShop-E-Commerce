using MediatR;
using SwiftShop.Order.Application.Features.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Queries.AddressQueries
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdQueryResult>
    {
        public int AddressId { get; set; }

        public GetAddressByIdQuery(int addressId)
        {
            AddressId = addressId;
        }
    }
}
