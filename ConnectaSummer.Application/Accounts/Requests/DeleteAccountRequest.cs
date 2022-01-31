using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.AccountHolders.Requests
{
    public class DeleteAccountRequest
    {
        public Guid AccountHolderId { get; set; }
    }
}
