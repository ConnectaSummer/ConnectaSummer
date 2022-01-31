using ConnectaSummer.Application.Account.Responses;
using ConnectaSummer.Application.AccountHolders.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
