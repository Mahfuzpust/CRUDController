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
        //create-Post
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
                TempData["mgs"] = "Fields created!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field can not submit";
                return View(model);
            }
        }
        //Delete
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(u => u.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["mgs"] = "Fileds deleted!";
            return RedirectToAction("Index");
        }

        //Edit
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(u => u.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary

            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id=model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["mgs"] = "Fields updated!";
            return RedirectToAction("Index");
        }
    }
}
