using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Contracts.Request.Users
{
    public record UpdateUserRequest(Guid id, string name, string username, string password)
    {
        public Guid Id { get; set; }
        
        [Length(3, 80, ErrorMessage = "Tamanho do Nome deve estar entre 3 a 80 caracteres")]
        public string Name { get; set; }

        [Length(3, 20, ErrorMessage = "Tamanho do Usuario deve estar entre 3 a 20 caracteres")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
    
}
