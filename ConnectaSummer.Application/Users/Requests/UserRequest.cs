using ConnectaSummer.Application.Users.Responses;
using MediatR;

namespace ConnectaSummer.Application.Users.Requests
{
    public class UserRequest:IRequest<UserResponse>
    {
        public string Login { get; set; }
        public int Page { get; set; }
        public int ItensPerPage { get; set; }

        public class UserResonse
        {
        }
    }
}