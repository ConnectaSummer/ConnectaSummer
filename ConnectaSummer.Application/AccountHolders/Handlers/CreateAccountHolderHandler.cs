using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Application.AccountHolders.Responses;
using ConnectaSummer.Domain.AccountHolders;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.AccountHolders.Handlers
{
    public class CreateAccountHolderHandler : IRequestHandler<CreateAccountHolderRequest, CreateAccountHolderResponse>
    {
        readonly IAccountHolderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHolderHandler(IAccountHolderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAccountHolderResponse> Handle(CreateAccountHolderRequest request, CancellationToken cancellationToken)
        {
            AccountHolder accountHolder = new AccountHolder(request.Name, request.City, request.PostCod);
            accountHolder.ReleaseSave();
            if (accountHolder.HasErrors)
            {
                CreateAccountHolderResponse response = new CreateAccountHolderResponse
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
                    CreateAccountHolderResponse response = new CreateAccountHolderResponse
                    {
                        Message = "Order saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    CreateAccountHolderResponse response = new CreateAccountHolderResponse
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
