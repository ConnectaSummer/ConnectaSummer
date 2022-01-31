using ConnectaSummer.Application.Account.Responses;
using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Application.AccountHolders.Responses;
using ConnectaSummer.Domain.AccountHolders;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Account.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        readonly IAccountHolderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHandler(IAccountHolderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            AccountHolder accountHolder = new AccountHolder(request.Name, request.TaxNumber);
            accountHolder.ReleaseSave();
            if (accountHolder.HasErrors)
            {
                CreateAccountResponse response = new CreateAccountResponse
                {
                    Erros = accountHolder.Errors,
                    Message = "error for create",
                    StatusCode = 400
                };
                return response;
            }
            else
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    await _repository.SaveAsync(accountHolder);
                    _unitOfWork.Commit();
                    CreateAccountResponse response = new CreateAccountResponse
                    {
                        Message = "Order saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    CreateAccountResponse response = new CreateAccountResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return response;
                }
            }
        }
    }
}