﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Contracts.Request.Users
{
    public record UpdateUserRequest(Guid id, string name, string username, string password);
}
