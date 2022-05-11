using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            DatabasePrograma db = new DatabasePrograma();
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente = db.GetCliente(cliente);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.UpdateCliente(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.InsertCliente(cliente);
            return RedirectToAction("index");
        }

        public IActionResult ExcluirConfirm(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(Cliente cliente)
        {
            DatabasePrograma db = new DatabasePrograma();
            db.DeleteCliente(cliente);
            return RedirectToAction("index");
        }


    }
}
