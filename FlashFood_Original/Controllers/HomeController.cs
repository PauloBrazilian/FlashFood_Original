using FlashFood_Original.Entidades;
using FlashFood_Original.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FlashFood_Original.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto db;

        public HomeController(ILogger<HomeController> logger, Contexto _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string login, string senha)
        {
            string senhaString = senha.ToString();
            Pessoa pessoa = db.Gerentes.Where(a => a.Nome == login && a.Senha == senha).FirstOrDefault();
            if (pessoa == null)
            {
                TempData["erro"] = "Erro no Login ou Senha";
                return View();
            }
            else
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, pessoa.Nome));
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));


                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Produtos");
            }
        }

        public IActionResult Produtos()
        {
            return View();
        }
        public async Task<IActionResult> LogOff()
        {
            
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
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