using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult //results folder is using for read processes. 
    //the result classes generally be named with Get key word. 
    //we are naming it as "QueryResult" because it should show that this is a query process. I mean it is returning some values. 
    //we could only name it with "Result", but the Command processes can be return some values too like information about the results of the creating process such as "The creating process is done."
    //so that dividing the results of a command process and a query processs make it more sense. 


    //result classes contains the data returned as a result of the Query.
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetails { get; set; }
    }
}
