using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;

namespace Wallet.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("A entidade não pode ser vazia")
                .NotNull().WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name).NotNull().WithMessage("O Nome não pode ser nulo")
                .NotEmpty().WithMessage("O Nome não pode estar vazio")
                .Length(3,80).WithMessage("Nome deve possuir no minimo 3 caracteres e no maixmo 80");

            RuleFor(x => x.Username).NotNull().WithMessage("O Username não pode ser nulo")
                .NotEmpty().WithMessage("O Username não pode estar vazio")
                .Length(3, 20).WithMessage("Username deve possuir no minimo 3 caracteres e no maximo 20");

            
        }
    }
}
