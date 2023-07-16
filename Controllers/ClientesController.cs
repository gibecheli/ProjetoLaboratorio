using Microsoft.AspNetCore.Mvc;

namespace ProjetoLaboratorio.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
