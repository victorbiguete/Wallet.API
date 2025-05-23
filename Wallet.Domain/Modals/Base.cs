using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Modals
{
    public abstract class Base
    {
        [Required]
        public Guid Id { get; init; } = Guid.NewGuid();

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}
