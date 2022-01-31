using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Operation.Responses
{
    public class DepositResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
