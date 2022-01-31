﻿using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Users.Responses
{
    public class CreateUserResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
