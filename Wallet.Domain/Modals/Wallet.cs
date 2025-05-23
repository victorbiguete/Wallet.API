using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Validators;

namespace Wallet.Domain.Modals
{
    public class Wallet: Base
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; private set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        public override bool Validate()
        {
            var validator = new WalletValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid) 
            {
                foreach (var item in validation.Errors)
                    _errors.Add(item.ErrorMessage);

                throw new Exception("Alguns campos estão invalidos, verifique" + _errors[0]);
            }
            return true;
        }

        public void ChangeBalance(decimal valor)
        {
            Balance += valor;
        }
    }
}
