using ConnectaSummer.Application.Login.Requests;
using ConnectaSummer.Application.Login.Responses;
using ConnectaSummer.Domain.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Login.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        IUserRepository _repository;

        public LoginHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = _repository.GetByLoginAndPass(request.Login,request.Pass);
            if (user == null)
            {
                LoginResponse response = new LoginResponse
                {
                    Message = "user or pass invalid",
                    StatusCode = 400
                };
                return response;
            }
            else
            {
                try
                {
                    LoginResponse response = new LoginResponse
                    {
                        StatusCode = 200
                    };
                    return response;
                }
                catch (Exception ex)
                {
                    LoginResponse response = new LoginResponse
                    {
                        Message = ex.Message,
                        StatusCode = 500
                    };
                    return response;
                }
            }
        }
    }
}