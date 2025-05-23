using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wallet.Services.Service.Interfaces;

namespace Wallet.Services.Service.Services
{
    public class AuthService : IAuthService
    {
        public void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmc = new HMACSHA512())
            {
                passwordSalt = hmc.Key;
                passwordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
