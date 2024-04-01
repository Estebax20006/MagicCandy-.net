using MagicCandy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagicCandy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult Ingreso()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult Carrito()
        {
            return View();
        }

        public IActionResult ProductoIngreso ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
