using FlashFood_Original.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace FlashFood_Original.Controllers
{
    public class PessoaController : Controller
    {

        private readonly Contexto _db;

        public PessoaController(Contexto contexto)
        {
            _db = contexto;
        }

        public IActionResult Index()
        {
            //Salva usuarios no banco
            _db.Gerentes.Add(new Entidades.Pessoa() { Nome = "Fer", Senha="ABC123" });
            _db.SaveChanges();


            return View( _db.Gerentes.ToList() );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa dados)
        {
            _db.Gerentes.Add(dados);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            return View( _db.Gerentes.Find(id) );
        }

        [HttpPost]
        public IActionResult Edit(Pessoa dados)
        {
            _db.Gerentes.Update(dados);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        IActionResult Cadastro(string Nome, int Senha)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                TempData["Erro"] = "O campo nome não pode estar em branco";
            }

            string senhaString = Senha.ToString();
            if (string.IsNullOrEmpty(senhaString))
            {
                TempData["Erro"] = "O campo Telefone não pode estar em branco";
            }
            return View("/Home/Produtos");
        }






    }


}