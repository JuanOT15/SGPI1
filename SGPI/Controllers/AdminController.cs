using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System.Linq;

namespace SGPI.Controllers
{
    public class AdminController : Controller
    {
        private SGPI_DBContext context;



        public AdminController(SGPI_DBContext contexto)
        {
            context = contexto;
        }

        public IActionResult AdministrarUsuario()
        {
            Usuario us = new Usuario();
            return View(us);
        }

        public IActionResult CrearUsuario()
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();

            return View();
        }




        [HttpPost]
        public IActionResult AdministrarUsuario(Usuario usuario)
        {
            var buscarUsuario = context.Usuarios.Where(u => u.Documento.Contains(usuario.Documento));

            if (buscarUsuario != null)
            {
                return View(buscarUsuario.FirstOrDefault());
            }
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public ActionResult Edit(Usuario usuario)
        {

            Usuario user = context.Usuarios.Find(usuario.IdUsuario);

            if (user == null)
            {
                return ViewBag.mensaje = "Error al editar el usuaiario";
            }

            usuario.Nombre = "";
            usuario.Apellido = "";

            context.Usuarios.Update(usuario);

            return View();
        }

        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = context.Usuarios.Find(usuario.IdUsuario);

            if (user == null)
            {
                return ViewBag.mensaje = "Error al eliminar el usuario";
            }
            else
            {
                context.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("AdministrarUsuario");
        }
    }
}
