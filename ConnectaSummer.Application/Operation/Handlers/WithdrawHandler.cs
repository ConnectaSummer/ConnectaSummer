using ConnectaSummer.Application.Operation.Requests;
using ConnectaSummer.Application.Operation.Responses;
using ConnectaSummer.Domain.Accounts;
using ConnectaSummer.Domain.Extracts;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Extracts.Handlers
{
    public class WithdrawHandler : IRequestHandler<WithdrawRequest, WithdrawResponse>
    {
        readonly IExtractRepository _repository;
        private readonly IAccountRepository _accountRepository;

        private readonly IUnitOfWork _unitOfWork;

        public WithdrawHandler(IExtractRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<WithdrawResponse> Handle(WithdrawRequest request, CancellationToken cancellationToken)
        {
            Extract extract = new Extract(request.Agency, request.NumberAccount, request.ReleaseDate, request.Value);
            extract.ReleaseSave();
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
                    _unitOfWork.Commit();
                    WithdrawResponse response = new WithdrawResponse
                    {
                        Message = "Order saved success",
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