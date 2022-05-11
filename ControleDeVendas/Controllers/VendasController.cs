using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        
        public IActionResult Criar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Venda venda)
        {
            DatabasePrograma db = new DatabasePrograma();
            Produto produto = new Produto();
            Cliente cliente = new Cliente();

            cliente.Id = venda.IdCliente;
            produto.Nome = venda.NomeProduto;
            
            venda.NomeCliente = db.GetCliente(cliente).Nome;
            venda.NomeProduto = db.GetProduto(produto).Nome;
            venda.Preco = db.GetProduto(produto).Preco;

            ViewBag.Quantidade = venda.Quantidade;
            ViewBag.Preco = venda.Preco;
            ViewBag.NomeCliente = venda.NomeCliente;
            ViewBag.NomeProduto = venda.NomeProduto;

            db.InsertVenda(venda);
            return RedirectToAction("Index", "Vendas", new { id = venda.IdCliente });
        }
    }
}
