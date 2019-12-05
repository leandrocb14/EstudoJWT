using EstudoJWT.DAO;
using EstudoJWT.Infraestrutura;
using EstudoJWT.MongoDB.Model;

namespace EstudoJWT.BLL
{
    public class BoUsuario
    {
        private readonly UsuarioDAO usuarioDAO;

        public BoUsuario()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public void AdicionarUsuario(Usuario pUsuario)
        {
            AvaliaPreenchimentoUsuario(pUsuario);
            usuarioDAO.Adicionar(pUsuario);
        }

        private void AvaliaPreenchimentoUsuario(Usuario pUsuario)
        {
            if (pUsuario == null)
                Erro.GerarErro(Erro.USUARIO_OBRIGATORIO);
            else
            {
                if (string.IsNullOrEmpty(pUsuario.Email))
                    Erro.GerarErro(Erro.EMAIL_USUARIO_OBRIGATORIO);
                if (string.IsNullOrEmpty(pUsuario.Senha))
                    Erro.GerarErro(Erro.SENHA_USUARIO_OBRIGATORIO);
            }            
        }

    }
}