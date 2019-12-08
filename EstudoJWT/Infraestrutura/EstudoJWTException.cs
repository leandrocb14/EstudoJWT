using System;

namespace EstudoJWT.Infraestrutura
{
    public class EstudoJWTException : Exception
    {
        public long CodigoErro { get; private set; }
        public EstudoJWTException(string message, long pCodigoErro) : base(message)
        {
            CodigoErro = pCodigoErro;
        }
    }
}