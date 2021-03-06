using ConnectaSummer.Application.Login.Responses;
using MediatR;

namespace ConnectaSummer.Application.Login.Requests
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Login { get; set; }

        public string Pass { get; set; }
    }
}