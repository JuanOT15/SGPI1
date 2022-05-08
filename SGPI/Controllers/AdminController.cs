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
            return View();
        }
        [HttpPost]
        public IActionResult AdministrarUsuario(Usuario user)
        {
            var listaUsuario = context.Usuarios
                .Where(u => u.Documento.Contains(user.Documento)).ToList();
            return View(listaUsuario);
        }


        public IActionResult CrearUsuario()
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            context.Add(usuario);
            context.SaveChanges();
            return View();
        }


        public IActionResult MenuAdmin()
        {
            return View();
        }

        /*
        public ActionResult BuscarUsuario(Usuario user)
        {
            Usuario usuario = context.Usuarios.Find(user.IdUsuario);
            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al eliminar el usuario, El usuario no existe";
            }
            user.Nombre = "";
            

            context.Usuarios.Update(user);
            return View();
        }

        public ActionResult Edit(Usuario user)
        {
            Usuario usuario = context.Usuarios.Find(user.IdUsuario);
                if (usuario == null)
            {
                return ViewBag.mensaje = "Error al eliminar el usuario, El usuario no existe";
            }
            return View();
        }

        public IActionResult Delete(Usuario user)
        {
            Usuario usuario = context.Usuarios.Find(user.IdUsuario);
                if (usuario == null)
            {
                return ViewBag.mensaje = "Error al eliminar el usuario, El usuario no existe";
            }
            else
            {
                context.Remove(user);
                context.SaveChanges();
            }
            return View();
        }
        */
    }
}
