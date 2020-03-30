using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GooglEexternalLoginSqlserver.Models;
using Model;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GooglEexternalLoginSqlserver.Controllers
{
    public class HomeController : Controller
    {

        //UserLogic user = new UserLogic();

        private readonly IUserDataService userDataService;
     //   private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<MyUser> signInManager;
        public HomeController(IUserDataService userDataService,
            SignInManager<MyUser> signInManager
           /* UserManager<IdentityUser> userManager*/)
        {
            this.signInManager = signInManager;
         //  this.userManager = userManager;
            this.userDataService = userDataService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Fail()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            //User user = new User()
            //{
            //    ReturnUrl = returnUrl,
            //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            //};

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password, string returnUrl)
        {
            //var result = await _userBusinessService.Login(Email, Password, Key);
            //if (result == true)
            //{
            //    return RedirectToAction("Success", "Home");
            //}


            return RedirectToAction("Fail", "Home");
        }

        public IActionResult Success(string msg)
        {

            return View(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Register(MyUser model )
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                // Store user data in AspNetUsers database table
               // var result1 = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                return RedirectToAction("Success", "Home", new { msg = "Success" });
                //if (result1.Succeeded)
                //{
                //    await signInManager.SignInAsync(user, isPersistent: false);
                //    return RedirectToAction("Success", "Home", new { msg = "Success" });
                //}

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                //foreach (var error in result1.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }

            return View(model);

            //var result = await userDataService.AddUser(newUser);

            //if (result != null)
            //{
            //    return RedirectToAction("Success", "Home", new { msg = "Success" });
            //}

            //return RedirectToAction("Fail", "Home", new { msg = "Success" });
        }
    }
}
