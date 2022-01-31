using ConnectaSummer.Application.Extracts.Responses;
using MediatR;
using System;

namespace ConnectaSummer.Application.Extracts.Requests
{
    public class CreateExtractRequest : IRequest<CreateExtractResponse>
    {

        public long AccountId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Value { get; set; }

        public long Nature { get; set; }
    }
}
