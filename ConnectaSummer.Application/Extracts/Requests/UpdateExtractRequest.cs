using ConnectaSummer.Application.Extracts.Responses;
using MediatR;
using System;

namespace ConnectaSummer.Application.Extracts.Requests
{
    public class UpdateExtractRequest : IRequest<UpdateExtractResponse>
    {
        public Guid ExtractId { get; protected set; }

        public string Name { get; set; }

        public void SetId(Guid extractId)
        {
            ExtractId = extractId;
        }
    }
}
