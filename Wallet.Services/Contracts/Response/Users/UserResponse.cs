using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Contracts.Response.Users
{
    public record UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid WalletId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
