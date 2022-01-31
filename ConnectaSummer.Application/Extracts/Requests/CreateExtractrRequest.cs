using ConnectaSummer.Application.Extracts.Responses;
using MediatR;

namespace ConnectaSummer.Application.Extracts.Requests
{
    public class CreateExtractrRequest : IRequest<CreateExtractResponse>
    {
        public string Name { get; set; }

        public string TaxNumber { get; set; }
    }
}
