using ConnectaSummer.Domain;
using System;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Users.Responses
{
    public class UpdateUserResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid UserId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}