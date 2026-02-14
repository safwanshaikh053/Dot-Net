using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    public class HomeController : Controller
    {
        EmpDbContext _dbContext = null;
        public HomeController(EmpDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var result = _dbContext.emps.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // ModelBinder : generate Models based on inputs : form Collection
        public IActionResult Create(Emp emp)
        {
            //ModelState
            _dbContext.emps.Add(emp);
            _dbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        // ModelBinder : generate Models based on inputs : form Collection
        public IActionResult Edit(int id)
        {
            //ModelState
            var empToBeUpdated = _dbContext.emps.FirstOrDefault(emp => emp.no == id);
        
            return View(empToBeUpdated);
        }
        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            _dbContext.emps.Update(emp);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            var empToBeDeleted = _dbContext.emps.FirstOrDefault(e => e.no == id);
            _dbContext.emps.Remove(empToBeDeleted);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}