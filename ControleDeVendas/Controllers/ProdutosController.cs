using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ExcluirConfirm(int id)
        {
            Produto produto = new Produto();
            produto.Id = id;
            return View(produto);
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.DeleteProduto(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            DatabasePrograma db = new DatabasePrograma();
            Produto produto = new Produto();
            produto.Id = id;
            produto = db.GetProduto(produto);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.UpdateProduto(produto);
            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.InsertProduto(produto);
            return RedirectToAction("index");
        }

    }
}
