using Depi_Project.context;
using Depi_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Depi_Project.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationContext context = new ApplicationContext() ;
        public IActionResult Index()
        {
            List<Employee> employeesModel = context.Employees.Include(e =>e.department).ToList();


            return View(employeesModel);
        }
        [HttpGet]
        public IActionResult New() 
        {
            ViewData["Depts"] = context.Departments.ToList();
            return View(); 
        }
        [HttpPost]
        public IActionResult New(Employee Newemployee) 
        {
            if (Newemployee.Name == null && Newemployee.department==null&&Newemployee.Age==0)
            {
                ViewData["Depts"] = context.Departments.ToList();
                return View(Newemployee);
            }
            context.Employees.Add(Newemployee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            Employee empModil = context.Employees.Include(e => e.department).FirstOrDefault(e => e.Employee_Id == id);

            if (empModil == null) 
            {
                return NotFound();  
            }
         
            return View(empModil);
        }
       



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var EmployeeModdel = context.Employees.Find(id);
            if (EmployeeModdel == null)
            {
                return NotFound();
            }

            return View(EmployeeModdel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var empModel = context.Employees.FirstOrDefault(D => D.Employee_Id == id);
            if (empModel == null)
            {
                return NotFound();
            }
            context.Employees.Remove(empModel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Employee empModle =context.Employees.FirstOrDefault(d => d.Employee_Id == id);
            ViewData["Depts"] = context.Departments.ToList();
            return View(empModle);

        }
        [HttpPost]
        public IActionResult Edit( [FromRoute] int id, Employee newEmp) 
        {
            if (newEmp.Name == null && newEmp.department == null && newEmp.Age == 0)
            {
                return View(newEmp);
            }
            Employee oldEmp = context.Employees.FirstOrDefault(e => e.Employee_Id == id);
            
            oldEmp.Name = newEmp.Name;
            oldEmp.Address = newEmp.Address;
            oldEmp.Age = newEmp.Age;
            oldEmp.PhoneNumber = newEmp.PhoneNumber;
            oldEmp.department = newEmp.department;
            


            context.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }

}

