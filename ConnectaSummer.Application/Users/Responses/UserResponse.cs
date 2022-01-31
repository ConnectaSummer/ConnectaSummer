﻿using System;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Users.Responses
{
    public class UserResponseItem
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }    

    }
    public class UserResponse
    {
        public List<UserResponseItem> Data { get; set; }
        public int Page { get; set; }

        public int PerPage { get; set; }

        public int LastPage { get; set; }

    }
}