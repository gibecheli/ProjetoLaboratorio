using Microsoft.AspNetCore.Mvc;
using ProjetoLaboratorio.Data;
using ProjetoLaboratorio.Models;
using System.Linq;

namespace ProjetoLaboratorio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Login bem-sucedido, redirecionar para a página de perfil do usuário, por exemplo.
                    return RedirectToAction("Profile", "User", new { id = user.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }
    }
}
