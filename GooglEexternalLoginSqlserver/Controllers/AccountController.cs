﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GooglEexternalLoginSqlserver.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
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
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            RegisterViewModel model= new RegisterViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =
                (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                new { ReturnUrl = returnUrl });
            var properties = signInManager
                .ConfigureExternalAuthenticationProperties(provider, redirectUrl);
          
            return new ChallengeResult(provider, properties);


            
        }

        //[AllowAnonymous]
        //public async Task<IActionResult>
        //    ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");

        //    RegisterViewModel loginViewModel = new RegisterViewModel
        //    {
        //        ReturnUrl = returnUrl,
        //        ExternalLogins =
        //                (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };

        //    if (remoteError != null)
        //    {
        //        ModelState
        //            .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

        //        return View("Login", loginViewModel);
        //    }

        //    // Get the login information about the user from the external login provider
        //    var info = await signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        ModelState
        //            .AddModelError(string.Empty, "Error loading external login information.");

        //        return View("Login", loginViewModel);
        //    }

        //    // If the user already has a login (i.e if there is a record in AspNetUserLogins
        //    // table) then sign-in the user with this external login provider
        //    var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider,
        //        info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

        //    if (signInResult.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    // If there is no record in AspNetUserLogins table, the user may not have
        //    // a local account
        //    else
        //    {
        //        // Get the email claim value
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);

        //        if (email != null)
        //        {
        //            // Create a new user without password if we do not have a user already
        //            var user = await userManager.FindByEmailAsync(email);

        //            if (user == null)
        //            {
        //                user = new ApplicationUser
        //                {
        //                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
        //                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
        //                };

        //                await userManager.CreateAsync(user);
        //            }

        //            // Add a login (i.e insert a row for the user in AspNetUserLogins table)
        //            await userManager.AddLoginAsync(user, info);
        //            await signInManager.SignInAsync(user, isPersistent: false);

        //            return LocalRedirect(returnUrl);
        //        }

        //        // If we cannot find the user email we cannot continue
        //        ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
        //        ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

        //        return View("Error");
        //    }
        //}

    }
}