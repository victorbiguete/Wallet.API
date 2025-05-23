using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Core.Exceptions
{
    public class DomainException : Exception
    {
        public List<string> _erros;
        public IReadOnlyCollection<string> Errors => _erros;

        public DomainException()
        {
        }

        public DomainException(string? message) : base(message)
        {
        }

        public DomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _erros = errors;
        }

        


    }
}
