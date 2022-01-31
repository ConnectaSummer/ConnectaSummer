using ConnectaSummer.Application.Extracts.Requests;
using ConnectaSummer.Application.Extracts.Responses;
using ConnectaSummer.Domain.Extracts;
using Data.UnityOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Extracts.Handlers
{
    public class CreateExtractHandler : IRequestHandler<CreateExtractrRequest, CreateExtractResponse>
    {
        readonly IExtractRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExtractHandler(IExtractRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateExtractResponse> Handle(CreateExtractRequest request, CancellationToken cancellationToken)
        {
            Extract extract = new Extract(request.Name, request.TaxNumber);
            extract.ReleaseSave();
            if (extract.HasErrors)
            {
                CreateExtractResponse response = new CreateExtractResponse
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
                    CreateExtractResponse response = new CreateExtractResponse
                    {
                        Message = "Order saved success",
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    CreateExtractResponse response = new CreateExtractResponse
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
