using API.Models;
using API.ViewModel;
using Client.Base;
using Client.Repositories;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : BaseController<Account, LoginRepository, string>
    {
        private readonly LoginRepository _loginRepository;
        public LoginController(LoginRepository loginRepository) : base(loginRepository)
        {
            this._loginRepository = loginRepository;
        }



        [HttpPost]
        public async Task<JsonResult> Auth(LoginVM login)
        {
            var jwtToken = await _loginRepository.Auth(login);
            var token = jwtToken.Token;

            if (token == null)
            {
                return Json(jwtToken);
            }

            HttpContext.Session.SetString("JWToken", token.ToString());

            return Json(jwtToken);

        }


        [HttpGet("Logout/")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");

        }



        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index" ,"TestCors");
            }
            return View();
        }
    }
}
