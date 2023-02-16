using CRUDController.Data;
using CRUDController.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDController.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field can not submit";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(u => u.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
