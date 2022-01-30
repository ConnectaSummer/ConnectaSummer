﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Accounts
{
    interface IAccountRepository
    {
        Task<Account> FindByIdAsync(Guid Id);
    }
}
