using ConnectaSummer.Domain;
using System;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Users.Responses
{
    public class DeleteUserResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid CustomerId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}