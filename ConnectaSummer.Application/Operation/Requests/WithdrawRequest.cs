using ConnectaSummer.Application.Operation.Responses;
using MediatR;

namespace ConnectaSummer.Application.Operation.Requests
{
    public class WithdrawRequest : IRequest<WithdrawResponse>
    {
        public string Agency { get; set; }

        public string AccountNumber { get; set; }

        public decimal Value { get; set; }
    }
}
