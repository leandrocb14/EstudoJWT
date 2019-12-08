
using System;

namespace EstudoJWT.Infraestrutura
{
    public static class Erro
    {
        #region Constantes Erros
        public const long ERRO_GENERICO = 0;
        public const long USUARIO_OBRIGATORIO = 1;
        public const long EMAIL_USUARIO_OBRIGATORIO = 2;
        public const long SENHA_USUARIO_OBRIGATORIO = 3;
        public const long EMAIL_EM_USO = 4;
        public const long USUARIO_NAO_ENCONTRADO = 5;
        #endregion

        #region Métodos
        public static void GerarErro(long pCodErro)
        {
            var msgErro = DetectarErro(pCodErro);
            throw new EstudoJWTException(msgErro, pCodErro);
        }

        private static string DetectarErro(long pCodErro)
        {
            switch (pCodErro)
            {
                default:
                case ERRO_GENERICO: return "Erro genérico.";
                case USUARIO_OBRIGATORIO: return "As informações do usuário são de preenchimento obrigatório!";
                case EMAIL_USUARIO_OBRIGATORIO: return "O email do usuário é de preenchimento obrigatório!";
                case SENHA_USUARIO_OBRIGATORIO: return "A senha do usuário é de preenchimento obrigatório!";
                case EMAIL_EM_USO: return "O e-mail digitado já está em uso!";
                case USUARIO_NAO_ENCONTRADO: return "Usuário não encontrado.";
            }
        }
        #endregion
    }
}