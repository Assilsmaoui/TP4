using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers
{
    public class DépartementController : Controller
    {
        private readonly CompanyDbContext context;

        public DépartementController(CompanyDbContext context)
        {
            this.context = context;
        }
        // GET: CompanyController
        public ActionResult Index()
        {
            return View(context.Departements.ToList());//departement trouvé dans la liste ecrire to list pour afficher 

        }

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement,string Name)//la création peut ecrire par le département l'objet ou par type primitive string
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (context.Departements.Where(
                        d => d.Name.ToLower()
                        == departement.Name.ToLower()).Any())
                    {
                        ModelState.AddModelError("", "le departement existe");
                        return View(departement);
                    }

                    context.Departements.Add(departement);
                    context.SaveChanges();//sauvgarde dans la base de donnée
                    return RedirectToAction(nameof(Index));//comme name n'est pas vide sont bdes condition 
                }
                return View(departement);
            }
            catch
            {
                return View(); 
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departement departement)
        {
            try
            {
                Departement dep = context.Departements.Where(d=>d.IdDepartement == id).FirstOrDefault();
                if (dep != null)
                {
                    dep.Name = departement.Name;
                    context.SaveChanges();
                }
              
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            Departement departement=context.Departements.Find(id);  
            return View(departement);
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departement departement)
        {
            try
            {
                context.Departements.Remove(departement);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
