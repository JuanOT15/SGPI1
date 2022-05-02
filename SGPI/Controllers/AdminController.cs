using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult CrearUsuario(Usuario usuario)
        {
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            return View();
        }

        public IActionResult MenuAdmin()
        {
            return View();
        }

    }
}
