using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        private SGPI_DBContext context;

        public CoordinadorController(SGPI_DBContext contexto)
        {
            context = contexto;
        }

        public IActionResult Consultas()
        {
            Usuario us = new Usuario();
            return View(us);
        }

        [HttpPost]
        public IActionResult Consultas(Usuario usuario)
        {
            var buscarUsuario = context.Usuarios.Where(u => u.Documento.Contains(usuario.Documento) && u.Rol == 3);

            if (buscarUsuario != null)
            {
                return View(buscarUsuario.FirstOrDefault());
            }
            return View();
        }

        public IActionResult EntrevistaAdmision()
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EntrevistaAdmision(Usuario usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipoDoc = context.TipoDocumentos.ToList();

            return View();
        }
        public IActionResult HomologacionAsignatura()
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.modulo = context.Modulos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult HomologacionAsignatura(Homologacion homologacion)
        {
            context.Add(homologacion);
            context.SaveChanges();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.modulo = context.Modulos.ToList();

            return View();
        }
        [HttpPost]

        public IActionResult HomologacionAsignatura(Homologacion homologacion )
        {
            var buscarUsuario = context.Homologacions.Where(u => u.Universidad.Contains(homologacion.Universidad));

            if (buscarUsuario != null)
            {
                return View(buscarUsuario.FirstOrDefault());
            }
            return View();
        }
        public IActionResult ProgramarAsignatura()
        {
            return View();
        }
        public IActionResult MenuCoordinador()
        {
            return View();
        }


    }
}
