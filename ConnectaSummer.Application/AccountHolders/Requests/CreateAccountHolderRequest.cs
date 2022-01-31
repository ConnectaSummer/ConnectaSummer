using ConnectaSummer.Application.AccountHolders.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class CreateExtractrRequest : IRequest<CreateAccountHolderResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }
    }
}
