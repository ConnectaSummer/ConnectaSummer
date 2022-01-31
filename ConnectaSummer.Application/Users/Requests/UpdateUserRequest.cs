using ConnectaSummer.Application.Users.Responses;
using MediatR;
using System;

namespace ConnectaSummer.Application.Users.Requests
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Login { get; set; }

        public string Pass { get; set; }

    }
}
