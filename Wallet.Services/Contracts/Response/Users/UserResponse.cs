using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Contracts.Response.Users
{
    public record UserResponse(Guid Id,string Name, Guid walletId, DateTime CreatedAt, DateTime LastUpdatedAt);
}
