using ConnectaSummer.Application.Operation.Requests;
using ConnectaSummer.Application.Operation.Responses;
using ConnectaSummer.Domain.Accounts;
using ConnectaSummer.Domain.Extracts;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Operation.Handlers
{
    public class DepositHandler : IRequestHandler<DepositRequest, DepositResponse>
    {
       
        private readonly IExtractRepository _repository;
        private readonly IAccountRepository _accountRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DepositHandler(IExtractRepository repository, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public async Task<DepositResponse> Handle(DepositRequest request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByAgencyAndAccountAsync(request.Agency, request.AccountNumber);
            var extract = new Extract();
            extract.Deposit(account, request.Value);

            if (extract.HasErrors)
            {
                DepositResponse response = new DepositResponse
                {
                    Erros = extract.Errors,
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
                    await _repository.SaveAsync(extract);
                    await _accountRepository.Update(account);
                    _unitOfWork.Commit();
                    DepositResponse response = new DepositResponse
                    {
                        Message = "Order saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    DepositResponse response = new DepositResponse
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