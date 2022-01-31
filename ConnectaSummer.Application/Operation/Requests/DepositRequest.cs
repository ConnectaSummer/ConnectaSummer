using ConnectaSummer.Application.Operation.Responses;
using MediatR;

namespace ConnectaSummer.Application.Operation.Requests
{
    public class DepositRequest : IRequest<DepositResponse>
    {
        public string AccountNumber { get; set; }
        public string Agency { get; set; }
        public decimal Value { get; set; }

    }
}
