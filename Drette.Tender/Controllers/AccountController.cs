﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drette.Tender.Shared.Models;
using Drette.Tender.ViewModels;
using Drette.Tender.Shared.Security;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Drette.Tender.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly IAuthenticationManager _authenticationManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegisterViewModel viewModel)
        {
            //If model is valid...
            if (ModelState.IsValid)
            {
                //Instantiate a User object
                var user = new User { UserName = viewModel.Email, Email = viewModel.Email };

                //Create the user
                var result = await _userManager.CreateAsync(user, viewModel.Password);

                //If User was successfully created...
                if (result.Succeeded)
                {
                    //Sign-in the user and redirect them to the web app's "Home" page
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    RedirectToAction("Index", "Products");
                }
                //If there were errors...
                //Add model errors
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

                return RedirectToAction("Index", "Products");
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(AccountSignInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Sign-in the user
            var result = await _signInManager.PasswordSignInAsync(
                viewModel.Email, viewModel.Password, viewModel.RememberMe, shouldLockout: false);

            // Check the result
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Products");
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(viewModel);
                case SignInStatus.LockedOut:
                case SignInStatus.RequiresVerification:
                    throw new NotImplementedException("Identity feature not implemented.");
                default:
                    throw new Exception("Unexpected Microsoft.AspNet.Identity.Owin.SignInStatus enum value: " + result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Products");
        }

    }
}