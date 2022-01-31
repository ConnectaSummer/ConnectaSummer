using ConnectaSummer.Application.Extracts.Requests;
using ConnectaSummer.Application.Extracts.Responses;
using ConnectaSummer.Domain.AccountHolders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Extracts.Handlers
{
    public class ExtractHandler : IRequestHandler<ExtractRequest, ExtractResponse>
    {
        readonly IAccountHolderRepository _repository;

        public ExtractHandler(IAccountHolderRepository repository)
        {
            _repository = repository;
        }

        public Task<ExtractResponse> Handle(ExtractRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}