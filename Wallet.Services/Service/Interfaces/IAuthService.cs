using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Services.Service.Interfaces
{
    public interface IAuthService
    {
        public void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        
    }
}
