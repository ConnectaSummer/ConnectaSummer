using ConnectaSummer.Application.Account.Responses;
using MediatR;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class CreateAccountRequest : IRequest<CreateAccountResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string Agency { get; set; }

        public string NumberAccount { get; set; }
    }
}