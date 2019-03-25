using System;

namespace CodeIT.Airlines.Challenge.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string mensagemErro)
            : base(mensagemErro)
        {
        }
    }
}
