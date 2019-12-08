using EstudoJWT.BLL;
using EstudoJWT.Infraestrutura;
using EstudoJWT.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;

namespace EstudoJWT.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly BoUsuario boUsuario;
        public AutenticacaoController()
        {
            boUsuario = new BoUsuario();
        }

        public ActionResult Autenticar(LoginViewModel pModel)
        {
            try
            {
                var usuario = boUsuario.BuscarUsuario(ConversorUsuario.ConvertToModelDAO(pModel));
                if (usuario == null)
                    Erro.GerarErro(Erro.USUARIO_NAO_ENCONTRADO);

                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id)
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // tempo de expiração do token: 1 hora
                var expiration = DateTime.UtcNow.AddHours(1);
                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: Request.Url.Host,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);
                UserToken userToken = new UserToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                };
                return Json(userToken);
            }
            catch (EstudoJWTException ex)
            {
                return View("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("Index", "Home");
            }
        }
    }
}