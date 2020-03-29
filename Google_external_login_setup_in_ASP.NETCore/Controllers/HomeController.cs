using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Google_external_login_setup_in_ASP.NETCore.Models;
using Google_external_login_setup_in_ASP.NETCore.Controllers.Models;
using Google_external_login_setup_in_ASP.NETCore.IRepository;

namespace Google_external_login_setup_in_ASP.NETCore.Controllers
{
    public class HomeController : Controller
    {

        //UserLogic user = new UserLogic();
        private readonly IUserRepository _userBusinessService;
        public HomeController(IUserRepository _userBusinessService)
        {
            this._userBusinessService = _userBusinessService;
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
        public async Task<IActionResult> Login(string Email, string Password, string Key)
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
        public async Task<IActionResult> Register(User newUser)
        {


            var result = await _userBusinessService.Add(newUser);

            if (result != null)
            {
                return RedirectToAction("Success", "Home", new { msg = "Success" });
            }

            return RedirectToAction("Fail", "Home", new { msg = "Success" });
        }
    }
}
