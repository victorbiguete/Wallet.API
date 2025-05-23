using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Contracts.Request.Wallet
{
    public record GetWallatRequest
    {
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
    }
}
