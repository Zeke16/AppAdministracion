using AppAdministracion.Data;
using AppAdministracion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdministracion.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppAdministracionContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public SolicitudesController(AppAdministracionContext context, UserManager<IdentityUser> contextUser)
        {
            _context = context;
            _userManager = contextUser;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Solicitudes> solicitudes = _context.Solicitudes;
            var users = await _userManager.Users.ToListAsync();

            foreach (var item in solicitudes)
            {
                item.Usuarios = users.Where(x => item.id_user == x.Id);
            }

            return View(solicitudes);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Solicitudes obj)
        {
            if (obj.descripcion != null)
            {
                obj.estado = 2;
                obj.id_user = _userManager.GetUserId(this.User);
                _context.Solicitudes.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Solicitudes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Solicitudes obj)
        {
            if (obj.descripcion != null)
            {
                _context.Solicitudes.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SolicitudEstado(int? id)
        {
            string estado = HttpContext.Request.QueryString.ToString().Replace("?condicion=", "");
            if (estado == "aceptar")
            {
                var solicitud = _context.Solicitudes.Find(id);
                solicitud.estado = 1;
                _context.Solicitudes.Update(solicitud);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (estado == "rechazar")
            {
                var solicitud = _context.Solicitudes.Find(id);
                solicitud.estado = 0;
                _context.Solicitudes.Update(solicitud);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _context.Solicitudes.Find(id);

            _context.Solicitudes.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
