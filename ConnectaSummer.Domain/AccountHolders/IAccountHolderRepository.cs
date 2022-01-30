﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.AccountHolders
{
    interface IAccountHolderRepository
    {
        Task<AccountHolder> FindByIdAsync(Guid Id);
    }
}