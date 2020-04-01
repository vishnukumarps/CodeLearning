
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SecurityVault.Web
{
    public class HomeController : Controller
    {

        //UserLogic user = new UserLogic();
        private readonly IUserDataService _service;
       // private readonly UserManager<IdentityUser> userManager;
       // private readonly SignInManager<IdentityUser> signInManager;
        public HomeController(IUserDataService _service
          // SignInManager<IdentityUser> signInManager, 
          // UserManager<IdentityUser> userManager
            )
        {
            this._service = _service;
          //  this.signInManager = signInManager;
            //this.userManager = userManager;
        }

        public IActionResult Index(string msg)
        {
          
            return View(msg);
        }

        public IActionResult Fail()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email,string Password)
        {
            var all=await _service.GetAllUser();
            var result=all.Where(x=>x.Email.ToLower()==Email.ToLower() && x.Password==Password).FirstOrDefault();
            if (result!=null)
            {
                return RedirectToAction("Success", "Home");
            }


            return RedirectToAction("Fail", "Home");
        }

        public IActionResult Success(string msg)
        {

            return View(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
        

            var result = await _service.AddUser(newUser);
          
            if (result!=null)
            {
                return RedirectToAction("Success", "Home", new { msg = "Success" });
            }

            return RedirectToAction("Fail", "Home", new { msg = "Success" });
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
        //                        new { ReturnUrl = returnUrl });
        //    var properties = signInManager
        //        .ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return new ChallengeResult(provider, properties);
        //}


    }
}
