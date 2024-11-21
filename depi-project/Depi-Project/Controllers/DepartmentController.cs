using Depi_Project.context;
using Depi_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Depi_Project.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        public IActionResult Index()
        {
            List<Department> depModel = context.Departments.ToList();
            return View(depModel);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Department New_department)
        {
            if (New_department.Department_Name != null)
            {
                context.Departments.Add(New_department);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(New_department);
        }

        

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var departmentModdel = context.Departments.Find(id);
            if (departmentModdel == null)
            {
                return NotFound();
            }

            return View(departmentModdel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var depModel = context.Departments.FirstOrDefault(D => D.Department_Id == id);
            if (depModel == null)
            {
                return NotFound();
            } 
            context.Departments.Remove(depModel); 
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
