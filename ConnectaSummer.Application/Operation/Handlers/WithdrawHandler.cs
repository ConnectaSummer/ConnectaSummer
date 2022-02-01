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
    public class WithdrawHandler : IRequestHandler<WithdrawRequest, WithdrawResponse>
    {

        private readonly IExtractRepository _repository;
        private readonly IAccountRepository _accountRepository;

        private readonly IUnitOfWork _unitOfWork;

        public WithdrawHandler(IExtractRepository repository, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public async Task<WithdrawResponse> Handle(WithdrawRequest request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByAgencyAndAccountAsync(request.Agency, request.AccountNumber);
            var extract = new Extract();
            extract.Withdraw(account, request.Value);

            if (extract.HasErrors)
            {
                WithdrawResponse response = new WithdrawResponse
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
                    WithdrawResponse response = new WithdrawResponse
                    {
                        Message = "Withdraw saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    WithdrawResponse response = new WithdrawResponse
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