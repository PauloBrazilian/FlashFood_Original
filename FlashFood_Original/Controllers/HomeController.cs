using FlashFood_Original.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlashFood_Original.Controllers
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
        
        [HttpPost]
        public IActionResult Produtos(string login, int senha)
        {
            string senhaString = senha.ToString();            
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(senhaString))
            {
                return View(); //libera para tela
            }
            else
            {
                TempData["erro"] = "Erro no Login ou Senha";
                return RedirectToAction("login");
            }
            
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}