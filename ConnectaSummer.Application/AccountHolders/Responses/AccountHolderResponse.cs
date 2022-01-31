using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.AccountHolders.Responses
{
    public class AccountHolderResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}