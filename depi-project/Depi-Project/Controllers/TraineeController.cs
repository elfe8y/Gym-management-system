using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Depi_Project.context;
using Depi_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Depi_Project.Controllers
{
   
    public class TraineeController : Controller
    {
         private readonly ApplicationContext _context;
        public TraineeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trainees = _context.Trainees.ToList();
            var sub = _context.Subscriptions.ToList();
            ViewBag.sub = sub ;
            return View(trainees);
        }

        public IActionResult createTrainee()
        {
            var sub = _context.Subscriptions.ToList();
            ViewBag.sub = sub ;
            return View();
        }
        public IActionResult addTrainee(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
            Console.WriteLine(trainee.type_Of_Subscription);
            return RedirectToAction("Index" ,"Trainee");
        }

        public IActionResult DeleteTrainee (int id){
            var trainee = _context.Trainees.Find(id);
            _context.Trainees.Remove(trainee);
            _context.SaveChanges();
            return RedirectToAction("index" , "Trainee");
        }

        public IActionResult UpdateTrainee (int id){
            var trainee = _context.Trainees.Find(id);
            var sub = _context.Subscriptions.ToList();
            ViewBag.sub = sub;
            return View(trainee);
        }
        
        public IActionResult EditTrainee(Trainee trainee){
            var traine = _context.Trainees.Find(trainee.Trainee_Id);
            traine.Name=trainee.Name;
            traine.Age=trainee.Age;
            traine.Address=trainee.Address;
            traine.Start_Of_Subscription=trainee.Start_Of_Subscription;
             traine.End_Of_Subscription=trainee.End_Of_Subscription;
             traine.PhoneNumber=trainee.PhoneNumber;
             traine.type_Of_Subscription = trainee.type_Of_Subscription;
            _context.Entry(traine).State = EntityState.Modified;
             _context.SaveChanges();
             return RedirectToAction("Index","Trainee");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}