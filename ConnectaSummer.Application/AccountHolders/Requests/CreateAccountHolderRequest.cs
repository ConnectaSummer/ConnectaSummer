using ConnectaSummer.Application.AccountHolders.Responses;
using MediatR;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class CreateExtractRequest : IRequest<CreateAccountHolderResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }
    }
}