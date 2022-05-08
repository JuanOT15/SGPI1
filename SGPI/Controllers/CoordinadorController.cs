using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        public IActionResult Consultas()
        {
            return View();
        }

        public IActionResult EntrevistaAdmision()
        {
            return View();
        }
        public IActionResult HomologacionAsignatura()
        {
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
