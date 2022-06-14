using API.Context;
using API.Models;
using API.Services;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {

        private readonly MyContext _context;
        public IConfiguration _configuration;
        private readonly Random _random = new Random();
        public AccountRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this._context = myContext;
            this._configuration = configuration;
        } 

        public int Login(LoginVM loginVM, out string Token)
        {

            if (CheckEmail(loginVM.Email))
            {
                var password = (from ac in _context.Accounts
                                join emp in _context.Employees
                                on ac.NIK equals emp.NIK
                                where emp.Email == loginVM.Email
                                select ac.Password).FirstOrDefault();

                var cekPass = CheckPassword(loginVM.Password, password);

                if (cekPass != false)
                {

                    /*var cekNik = (from emp in _context.Employees
                                  where emp.Email == loginVM.Email
                                  select emp).FirstOrDefault();*/

                /*    var NIK = cekNik.NIK;*/

                    var CheckRole = (from emp in _context.Employees
                                     join acr in _context.AccountRoles
                                     on emp.NIK equals acr.AccNIK
                                     join r in _context.Roles
                                     on acr.RoleId equals r.Id
                                     where emp.Email == loginVM.Email
                                     select r).ToList();

             /*       var employee = (from emp in _context.Employees                                 
                                    where emp.Email == loginVM.Email
                                     select emp).ToList();*/


                    var claims = new List<Claim>();
                    claims.Add(new Claim("Email", loginVM.Email));
                    foreach (var roles in CheckRole)
                    {
                        claims.Add(new Claim("roles", roles.RoleName));
                    }
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["JwtConstants:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn
                        );

                    var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                    claims.Add(new Claim("Token Security", idtoken.ToString()));

                    Token = idtoken;
                    return 200;
                }

                Token = null;
                return 404;
            }

            Token = null;
            return 400;

        }
        
        public string ForgotPassword(ForgotPasswordVM forgotPassword)
        {
           Employee employee = _context.Employees.FirstOrDefault(employee => employee.Email == forgotPassword.Email);
         

            if (employee == null)
            {
                return "Account tidak ditemukan";
            }

            Account account = (from emp in _context.Employees
                               join acc in _context.Accounts
                               on emp.NIK equals acc.NIK
                               where emp.Email == forgotPassword.Email
                               select acc).FirstOrDefault();

            account.OTP = RandomString(6);
            account.ExipiredTime = DateTime.Now.AddMinutes(5);
            account.IsActive = true;
            _context.Entry(account).State = EntityState.Modified;


            SendMessage(forgotPassword.Email,
                $"ForgotPassword, Mr/Mrs {employee.FirstName}", 
                $"OTP : {account.OTP} will expire after 5 minutes");

            if (_context.SaveChanges() > 0 )   
            {
                return "OTP telah dikirim ke email anda";
            }
            return "Pengiriman OTP gagal !";
        }


        public string ChangePassword(ValidatePasswordVM validatePassword)
        {
            Employee employee = _context.Employees.SingleOrDefault(employee => employee.Email == validatePassword.Email);
            if (employee == null)
            {
                return "Email tidak terdaftar !";
            }
            if (validatePassword.Password != validatePassword.ValidateNewPassword)
            {
                return "Password tidak cocok !";
            }

            Account acc = _context.Accounts.FirstOrDefault(acc => acc.OTP == validatePassword.OTP);

            if (DateTime.Now > acc.ExipiredTime)
            {
                acc.IsActive = false;
                _context.Entry(acc).State = EntityState.Modified;
                return "OTP is Expired";
            }
            acc.Password = HashPassword(validatePassword.Password);
            _context.Entry(acc).State = EntityState.Modified;
            if (_context.SaveChanges() > 0)
            {
                return "Your password has been updated";
            }
            return "Failed to update your password";
        }

        public string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public bool CheckPassword(string password, string correctHash)
        {

            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

        public bool CheckEmail(string email)
        {
            Employee employee = _context.Employees.FirstOrDefault(employee => employee.Email == email);
            return employee != null;
        }

        public static void SendMessage(string emailTo, string subject, string body)
        {
            var client = new SmtpClient("smtp.ethereal.email", 587)
            {
                Credentials = new NetworkCredential("amalia.abernathy73@ethereal.email", "duMyzzM1MpW8d2usys"),
                EnableSsl = true
            };
            client.Send("amalia.abernathy73@ethereal.email", "amalia.abernathy73@ethereal.email", subject, body);

        }

        
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);


            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26   

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }




        /* public int SignManager(Assign assign)
         {
             AccountRole accountRole = _context.AccountRoles.Where(ac => ac.AccNIK == assign.NIK && ac.RoleId == 2).SingleOrDefault();
             if (accountRole != null)
             {
                 return 400;
             }

             AccountRole er = new AccountRole
             {
                 AccNIK = assign.NIK,
                 RoleId = 2
             };
             _context.AccountRoles.Add(er);
             var result = _context.SaveChanges();
             return result;
         }*/




    }
}
