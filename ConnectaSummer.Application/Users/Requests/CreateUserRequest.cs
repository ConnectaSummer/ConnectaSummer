using ConnectaSummer.Application.Users.Responses;
using MediatR;

namespace ConnectaSummer.Application.Users.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Login { get; set; }

        public string Pass { get; set; }
    }
}