using EstudoJWT.Models;
using EstudoJWT.MongoDB.Model;

namespace EstudoJWT.Infraestrutura
{
    public static class ConversorUsuario
    {
        public static Usuario ConvertToModelDAO(LoginViewModel pUsuarioViewModel)
        {
            var usuario = new Usuario();
            usuario.Email = pUsuarioViewModel.Email;
            usuario.Senha = pUsuarioViewModel.Senha;
            return usuario;
        }

        public static Usuario ConvertToModelDAO(RegistrarViewModel pRegistrarViewModel)
        {
            var usuario = new Usuario();
            usuario.Email = pRegistrarViewModel.Email;
            usuario.Senha = pRegistrarViewModel.Senha;
            return usuario;
        }
    }
}