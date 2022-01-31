using ConnectaSummer.Application.Extracts.Responses;
using MediatR;

namespace ConnectaSummer.Application.Extracts.Requests
{
    public class ExtractRequest : IRequest<ExtractResponse>
    {
        public string Account { get; set; }

        public string Agenct { get; set; }
    }
}