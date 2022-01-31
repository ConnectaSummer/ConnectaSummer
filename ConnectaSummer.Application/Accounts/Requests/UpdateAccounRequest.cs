using ConnectaSummer.Application.Account.Responses;
using MediatR;
using System;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class UpdateAccountRequest: IRequest<UpdateAccountResponse>
    {
        public Guid AccountHolderId { get; protected set; }

        public string Name { get; set; }

        public void SetId(Guid accountHolderId)
        {
            AccountHolderId = accountHolderId;
        }
    }
}