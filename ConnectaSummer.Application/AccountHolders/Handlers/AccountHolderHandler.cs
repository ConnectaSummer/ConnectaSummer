using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Application.AccountHolders.Responses;
using ConnectaSummer.Domain.AccountHolders;
using MediatR;

namespace ConnectaSummer.Application.AccountHolders.Handlers
{
    public class AccountHolderHandler : IRequestHandler<AccountHolderRequest, AccountHolderResponse>
    {
        readonly IAccountHolderRepository _repository;
    }
}
