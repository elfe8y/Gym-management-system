
using Depi_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Depi_Project.IdentityModels;

namespace Depi_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger)
        {
            this.userManager = userManager;
            this.signInManger = signInManger;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userVm)
        {
            var res = User.Identity.IsAuthenticated;
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userVm.UserName;
                user.PasswordHash = userVm.Password;
                IdentityResult registerResult = await userManager.CreateAsync(user, userVm.Password);
                
                if (registerResult.Succeeded)
                {
                    //sign in cookie
                   // await userManager.AddToRoleAsync(user, "Admin");
                   // await signInManger.SignInAsync(user, false);
                     res = User.Identity.IsAuthenticated;
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    foreach (var error in registerResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(userVm);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            //validation ==> state 
            if (ModelState.IsValid)
            {
                //check if user exists 
                var applicationUser = await userManager.FindByNameAsync(model.UserName);
                Console.WriteLine("i have do not");
                if (applicationUser != null)
                {
                    //check user pass ==> 
                    var exists = await userManager.CheckPasswordAsync(applicationUser, model.Password);
                    Console.WriteLine("password wrong");
                    if (exists)
                    {
                        //create cookies ==> 
                        //await _signInManager.SignInAsync(applicationUser, model.RemmberMe);//(Id,Name,Role)
                        List<Claim> claims = new List<Claim>();
                        // claims.Add(new Claim("userAdderss", applicationUser.Address));
                        //  await signInManger.SignInWithClaimsAsync(applicationUser, model.RemmberMe, claims);//Id,Name,Role,userAddress
                        await signInManger.SignInAsync(applicationUser, model.RemmberMe);
                        Console.WriteLine("i have done");
                        return RedirectToAction("index", "Home");
                    }
                }
                else
                    ModelState.AddModelError("", "user name or pass is incorrect");
            }

            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManger.SignOutAsync();
            //return RedirectToAction("Register");
            return RedirectToAction(nameof(Register));
        }
    }
}
