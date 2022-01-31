using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Account.Responses
{
    public class AccountResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}