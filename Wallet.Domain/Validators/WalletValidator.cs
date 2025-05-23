using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;

namespace Wallet.Domain.Validators
{
    public class WalletValidator : AbstractValidator<Modals.Wallet>
    {
        public WalletValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("A entidade não pode ser vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");
        }
    }
}
