using EstudoJWT.DAO;
using EstudoJWT.Infraestrutura;
using EstudoJWT.MongoDB.Model;

namespace EstudoJWT.BLL
{
    public class BoUsuario
    {
        #region Propriedades
        private readonly UsuarioDAO usuarioDAO;
        #endregion

        #region Métodos
        #region Métodos Publicos
        public BoUsuario()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public void AdicionarUsuario(Usuario pUsuario)
        {
            AvaliaPreenchimentoUsuario(pUsuario);
            if (usuarioDAO.BuscaUsuarioPorEmail(pUsuario.Email) != null)
                Erro.GerarErro(Erro.EMAIL_EM_USO);

            usuarioDAO.Adicionar(pUsuario);
        }
        public Usuario BuscarUsuario(Usuario pUsuario)
        {
            return usuarioDAO.BuscaUsuarioPorEmailESenha(pUsuario);
        }
        #endregion

        #region Métodos Privados
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
        #endregion
        #endregion

    }
}