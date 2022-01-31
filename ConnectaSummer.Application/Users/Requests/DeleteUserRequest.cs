using ConnectaSummer.Application.Users.Responses;
using MediatR;
using System;

namespace ConnectaSummer.Application.Users.Requests
{
    public class DeleteUserRequest:IRequest<DeleteUserResponse>
    {
        public void SetId(Guid userid)
        {
            UserId = userid;
        }
        public Guid UserId { get; private set; }
        public string Login { get; set; }

        public string Pass { get; set; }
    }
}