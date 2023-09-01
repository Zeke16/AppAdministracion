using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdministracion.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Empleado"))
            {
                Response.Redirect("/Home/Index");
            }
            ViewData["countUser"] = _userManager.Users.Count();
            return View();
        }
    }
}
