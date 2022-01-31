using ConnectaSummer.Application.AccountHolders.Responses;
using MediatR;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class AccountHolderRequest : IRequest<AccountHolderResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }
    }
}
