using Depi_Project.context;
using Depi_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Depi_Project.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationContext _context;
        public SubscriptionController(ApplicationContext context)
        {
            _context = context;
        }
        

        public IActionResult Index(){

            var subs = _context.Subscriptions.ToList();
            return View(subs);

        }

        public IActionResult addSubscription(){
            return View();
        }

        public IActionResult addSub(Subscription sub){
            _context.Subscriptions.Add(sub);
            _context.SaveChanges();
            return RedirectToAction("Index" , "Subscription");
        }

        public IActionResult UpdateSubscrtiption(int id){
            var sub = _context.Subscriptions.Find(id);

            return View(sub);
        }

        public IActionResult EditSub(Subscription subscription){
            var sub = _context.Subscriptions.Find(subscription.Subscription_Id);
            Console.WriteLine(sub.Name);
            Console.WriteLine(subscription.Name);
              _context.Entry(sub).State = EntityState.Modified;
            sub.Name = subscription.Name;
            sub.price = subscription.price;
            sub.Description = subscription.Description;
            _context.SaveChanges();
            return RedirectToAction("Index" , "Subscription");
        }

        public IActionResult DeleteSub(int id){

            var Sub = _context.Subscriptions.Find(id);
            _context.Subscriptions.Remove(Sub);
            _context.SaveChanges();
            return RedirectToAction("Index" , "Subscription");
        }
    }
}