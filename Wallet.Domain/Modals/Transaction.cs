using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Enum;

namespace Wallet.Domain.Modals
{
    public class Transaction : Base
    {
        public Guid SendWalletId { get; set; }

        public Guid ReceiverWalletId { get; set; }
        public TypeTransaction Type { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
