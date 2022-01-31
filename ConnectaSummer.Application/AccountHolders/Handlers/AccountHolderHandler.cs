using ConnectaSummer.Application.Account.Requests;
using ConnectaSummer.Application.Account.Responses;
using ConnectaSummer.Domain.AccountHolders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.AccountHolders.Handlers
{
    public class ExtractHandler : IRequestHandler<AccountRequest, AccountResponse>
    {
        readonly IAccountHolderRepository _repository;

        public ExtractHandler(IAccountHolderRepository repository)
        {
            _repository = repository;
        }

        public Task<AccountResponse> Handle(AccountRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}