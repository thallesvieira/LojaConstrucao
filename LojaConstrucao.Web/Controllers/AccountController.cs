using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Domain;
using LojaConstrucao.Domain.Products;
using LojaConstrucao.Domain.Sales;
using LojaConstrucao.Web.ViewsModels;
using LojaConstrucao.Domain.Account;

namespace LojaConstrucao.Web.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly  IAuthentication  _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}