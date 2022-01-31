using ConnectaSummer.Application.Account.Responses;
using MediatR;

namespace ConnectaSummer.Application.Account.Requests
{
    public class AccountRequest : IRequest<AccountResponse>
    {
        public string Agency { get; set; }

        public string NumberAccount { get; set; }
    }
}