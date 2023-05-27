using Microsoft.AspNetCore.Mvc;


namespace FlashFood_Original.Controllers
{
    public class PessoaController : Controller
    {

        private readonly Contexto _db;

        public PessoaController(Contexto contexto)
        {

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
                return View("Home/Produtos");
            }


        }

      
        
    }


}