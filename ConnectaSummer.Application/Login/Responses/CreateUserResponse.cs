using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Login.Responses
{
    public class LoginResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }
    }
}