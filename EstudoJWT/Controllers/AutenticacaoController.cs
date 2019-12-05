using EstudoJWT.BLL;
using EstudoJWT.Infraestrutura;
using EstudoJWT.Models;
using System;
using System.Text;
using System.Web;
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
        // GET: Autenticacao
        public ActionResult Index()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            return View(usuarioViewModel);
        }

        public ActionResult Registrar(UsuarioViewModel model)
        {
            try
            {
                boUsuario.AdicionarUsuario(ConversorUsuario.ConvertToModelDAO(model));
                TempData["IsSuccess"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["IsError"] = ex.Message;
                return View("Index");
            }
            
        }

        public ActionResult Autenticar()
        {
            return View();
        }
    }
}