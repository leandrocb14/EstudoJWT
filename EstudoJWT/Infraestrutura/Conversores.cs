using EstudoJWT.Models;
using EstudoJWT.MongoDB.Model;

namespace EstudoJWT.Infraestrutura
{
    public static class ConversorUsuario
    {
        public static Usuario ConvertToModelDAO(UsuarioViewModel pUsuarioViewModel)
        {
            var usuario = new Usuario();
            usuario.Id = pUsuarioViewModel.Id;
            usuario.Email = pUsuarioViewModel.Email;
            usuario.Senha = pUsuarioViewModel.Senha;
            return usuario;
        }

        public static UsuarioViewModel ConvertToModel(Usuario pUsuario)
        {
            var usuario = new UsuarioViewModel();
            usuario.Id = pUsuario.Id;
            usuario.Email = pUsuario.Email;
            usuario.Senha = pUsuario.Senha;
            return usuario;
        }
    }
}