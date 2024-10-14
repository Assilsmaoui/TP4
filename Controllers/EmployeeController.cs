using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TP4.Models;
using TP4.ViewModel;

namespace TP4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext context;

        public EmployeeController(CompanyDbContext context) {
            this.context = context;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            //1.utiliser la jointure avec class EmployeeVM dans le dossier ViewModel
            var list = from em in context.Employees
                       join
  
                        dep in context.Departements
  
                       on em.IdDepartement equals dep.IdDepartement
                       select new EmployeeVM
                       {
                           EmployeeId = em.EmployeeId,
                           Name = em.Name,
                           Address = em.Address,
                           Designation = em.Designation,
                           Salary = em.Salary,
                           JoiningDate = em.JoiningDate,
                           NomDepartement = dep.Name
                       };
            // return View(list);
            //2.utiliser la méthode virtuelle
            List<Employee> emps = context.Employees
            .Include(d => d.IdDepartementNavigation)
            .ToList();
            return View(emps);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
          /*  var depts = new List<SelectListItem>()
           {
               context.Departements.Select(d => new SelectListItem()
               {
               Text = d.Name,
               Value=d.IdDepartement.ToString()
               })
           };*/
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
