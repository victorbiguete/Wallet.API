using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Exceptions;
using Wallet.Domain.Validators;

namespace Wallet.Domain.Modals
{
    public class User : Base
    {
        [Required(ErrorMessage = "Nome deve ser inserido")]
        [Length(2,80,ErrorMessage = "Tamanho do Nome deve ser entre 2 a 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username deve ser inserido")]
        [Length(5,20,ErrorMessage = "Tamanho do Usuario deve ser entre 5 a 20 caracteres")]
        public string Username { get; set; }

        public byte[] PasswordHash { get;  set; }
        public byte[] PasswordSalt { get;  set; }
        public Guid WalletId { get;  set; }
        public Wallet Wallet { get;  set; } = new Wallet();
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public DateTime LastUpdatedAt { get;  set; } = DateTime.Now;

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão invalidos, verifique",
                                          _errors);
            }

            return true;
        }

        public User(string name, string username, byte[] passwordHash, byte[] passwordSalt, Guid walletId, Wallet wallet, DateTime createdAt, DateTime lastUpdatedAt)
        {
            Name = name;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            WalletId = walletId;
            Wallet = wallet;
            CreatedAt = createdAt;
            LastUpdatedAt = lastUpdatedAt;
        }

        public User()
        {
        }
    }
}
