using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController :  BaseController<Account, AccountRepository, string>
    {

        private readonly AccountRepository _accountRepository;
        public IConfiguration _configuration;


        public AccountController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this._accountRepository = accountRepository;
            this._configuration = configuration;
        }


        [HttpPost("Login")]
        public ActionResult Post(LoginVM loginVM )
        {

            string Token;
            int TokeLogin = _accountRepository.Login(loginVM, out Token);


            if (_accountRepository.Login(loginVM, out Token) == 200)
            {
                return StatusCode(200, new { status = Convert.ToInt32(HttpStatusCode.OK), Token = Token, message = "Loggin" });
            }
            else if (_accountRepository.Login(loginVM, out Token) == 404)
            {
                return StatusCode(404, new { status = Convert.ToInt32 (HttpStatusCode.NotFound), Token = Token, message = "Gagal Login : Password Salah!" });
            }
            else
            {
                return StatusCode(400, new { status = Convert.ToInt32(HttpStatusCode.BadRequest),Token = Token, message = "Gagal Login : Email tidak ditemukan!" });
            }
        }

        [HttpPost("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPassword )
        {

            return Ok(_accountRepository.ForgotPassword(forgotPassword));
        }

        [HttpPost("ChangeForgotPassword")]
        public ActionResult ChangePassword(ValidatePasswordVM validatePassword)
        {

            return Ok(_accountRepository.ChangePassword(validatePassword));
        }

        [Authorize]
        [HttpGet("TestJWT")]
        public  ActionResult TestJWT()
        {
            return Ok("Test JWT Berhasil");
        }


        /*[Authorize(Roles = "Directur")]
        [HttpPost("SignManager")]
        public ActionResult SignManager(Assign assign)
        {
            if (_accountRepository.SignManager(assign) == 400)
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Sudah Menjadi Manager !" });
            }
            return StatusCode(200, new { status = HttpStatusCode.OK, message = "Berhasil diangkat menjadi Manager" });
        }*/







    }
}
