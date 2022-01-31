using ConnectaSummer.Application.Operation.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Operation.Requests
{
    public class WithdrawRequest : IRequest<WithdrawResponse>
    {
        public string Agency { get; set; }

        public string NumberAccount { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Value { get; set; }
    }
}
