using ConnectaSummer.Domain;
using System;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Account.Responses
{
    public class CreateAccountResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid AccountHolderId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
