﻿using ConnectaSummer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Application.Account.Responses
{
    public class DeleteAccountResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
