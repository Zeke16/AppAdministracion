using AppAdministracion.Data;
using AppAdministracion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdministracion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppAdministracionContext _dbContext;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, AppAdministracionContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Identity/Account/Login");
            }
            ViewData["userId"] = _userManager.GetUserId(this.User);
            ViewData["countDep"] = _dbContext.Departamentos.Count();
            ViewData["countSol"] = _dbContext.Solicitudes.Count();
            ViewData["countUser"] = _userManager.Users.Count();
            return View();
        }
        

        public IActionResult Privacy()
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
