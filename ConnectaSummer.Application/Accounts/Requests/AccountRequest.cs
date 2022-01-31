using ConnectaSummer.Application.Account.Responses;
using MediatR;

namespace ConnectaSummer.Application.Account.Requests
{
    public class AccountRequest : IRequest<AccountResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }
    }
}
