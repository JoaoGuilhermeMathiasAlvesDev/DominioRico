using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string mensagem) : base(mensagem) { }

        public DomainException(string mensagem, Exception innerExeception) : base(mensagem, innerExeception) { }


    }
}
