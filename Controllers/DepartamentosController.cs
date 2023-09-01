using AppAdministracion.Data;
using AppAdministracion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppAdministracion.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly AppAdministracionContext _context;
        public DepartamentosController(AppAdministracionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Empleado"))
            {
                Response.Redirect("/Home/Index");
            }
            IEnumerable<Departamentos> departamentos = _context.Departamentos;
            return View(departamentos);
        }

        public IActionResult Create()
        {   
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamentos obj)
        {
            if (ModelState.IsValid)
            {
                _context.Departamentos.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Departamentos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamentos obj)
        {
            if (ModelState.IsValid)
            {
                _context.Departamentos.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id) 
        {
            var obj = _context.Departamentos.Find(id);

            _context.Departamentos.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
