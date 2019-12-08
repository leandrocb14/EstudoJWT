using EstudoJWT.BLL;
using System.Web.Mvc;
using System;
using EstudoJWT.Infraestrutura;
using EstudoJWT.Models;

namespace EstudoJWT.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoUsuario boUsuario;

        public HomeController()
        {
            boUsuario = new BoUsuario();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(RegistrarViewModel model)
        {
            try
            {
                boUsuario.AdicionarUsuario(ConversorUsuario.ConvertToModelDAO(model));
                TempData["IsSuccess"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (EstudoJWTException ex)
            {
                TempData["IsError"] = ex.Message;
                return View("Index");
            }
            catch(Exception ex)
            {
                TempData["IsError"] = ex.Message;
                return View("Index");
            }
        }
    }
}