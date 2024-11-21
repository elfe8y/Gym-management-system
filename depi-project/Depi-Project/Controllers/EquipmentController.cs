using Depi_Project.context;
using Depi_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Depi_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Depi_Project.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Depi_Project.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationContext _context;
        public EquipmentController(ApplicationContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int page = 1, int pageSize = 9)
        {
            var equipmentList = _context.Equipments.ToList(); 
            var totalItems = equipmentList.Count(); 
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize); 

            
            var equipmentToShow = equipmentList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page; 
            ViewBag.TotalPages = totalPages; 

            return View(equipmentToShow); 
        }


        public async Task<IActionResult> Create()
        {
            var createViewModel = new EquipmentFormViewModel
            {
                StatusOptions = new List<string> { "Available", "In Maintenance", "Out of Service" }
            };
            return View("EquipmentForm", createViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentFormViewModel model)
        {
            if (!ModelState.IsValid)
            {


                return View("EquipmentForm", model);
            }
            var Equip = new Equipment()
            {
                Equipment_Name = model.Equipment_Name,
                Maintainance_Date = model.Maintainance_Date,
                Status = model.Status,
            };
            _context.Equipments.Add(Equip);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)  
                return BadRequest();

            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment == null)
                return NotFound();

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

     
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var equipment = _context.Equipments.Find(id);
            if (equipment == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new EquipmentFormViewModel
            {
                Equipment_Id = equipment.Equipment_Id,
                Equipment_Name = equipment.Equipment_Name,
                Maintainance_Date = equipment.Maintainance_Date,
                Status = equipment.Status,
                StatusOptions = new List<string> { "Available", "In Maintenance", "Out of Service" }
            };

            return View("EquipmentForm", model);
        }


        [HttpPost]
        public IActionResult Edit(int id, EquipmentFormViewModel model)
        {
            var equipment = _context.Equipments.Find(id);
            if (equipment == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return View("EquipmentForm", model);
            }

            equipment.Equipment_Name = model.Equipment_Name;
            equipment.Status = model.Status;
            equipment.Maintainance_Date = model.Maintainance_Date;

            _context.Equipments.Update(equipment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}