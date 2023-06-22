using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            try
            {
                Usuario usuarioLogueado = _sistema.LoginUsuario(email, pass);
                string rol = _sistema.ObtenerRolUsuario(email, pass);

                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", rol);


                if (rol == "huesped")
                {
                    Huesped huespedLogueado = usuarioLogueado as Huesped;

                    HttpContext.Session.SetInt32("edad", huespedLogueado.Edad());
                    HttpContext.Session.SetString("nombre", huespedLogueado.Nombre);

                    return Redirect("/Actividad/ActividadesPorFecha");
                }
                else if (rol == "operador")
                    return Redirect("/Proveedor/Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View("login");

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult CreateHuesped()
        {
            ViewBag.TiposDocumento = _sistema.TiposDeDocumento;
            return View(new Huesped());
        }

        [HttpPost]
        public IActionResult CreateHuesped(Huesped huesped, int tipoDocumento, string numDocumento)
        {
            try
            {
                Huesped huespedCreado = huesped;
                huespedCreado.Documento = new Documento(tipoDocumento, numDocumento);

                _sistema.AgregarHuesped(huespedCreado);
                return RedirectToAction("Login", new { mensaje = "Registrado correctamente" });
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                ViewBag.TiposDocumento = _sistema.TiposDeDocumento;
            }
            return View(huesped);
        }

        [HttpGet]
        [Logueado]
        public IActionResult MostrarUsuario()
        {
            ViewBag.Usuario = _sistema.ObtenerUsuario(HttpContext.Session.GetString("email"));


            return View("MostrarUsuario");
        }
    }
}

