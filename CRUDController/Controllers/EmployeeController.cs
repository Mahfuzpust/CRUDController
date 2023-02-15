using CRUDController.Data;
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
    }
}
