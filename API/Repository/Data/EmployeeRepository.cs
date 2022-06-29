using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.ViewModel;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>

    {
        private readonly MyContext _context;

        public EmployeeRepository(MyContext myContext): base(myContext)
        {
            this._context = myContext;
        }

        public int Insert(RegisterEmployeeVM registerEmployee)
        {
            Employee  em = new Employee();
            Account   ac = new Account();
            Education ed = new Education();

            //DateTime.Now.ToString("MMddYYYY");

            //Employee
            em.NIK = GetAutoIncrementNIK(); 
            em.FirstName = registerEmployee.FirstName;
            em.LastName  = registerEmployee.LastName;
            em.Email     = registerEmployee.Email;
            em.Phone     = registerEmployee.Phone;
            em.Salary    = registerEmployee.Salary;
            em.Birthday  = registerEmployee.Birthday;
            em.Gender    = (Gender)Enum.Parse(typeof(Gender), registerEmployee.Gender);


            //Account
            ac.Password = HashPassword(registerEmployee.Password);
           

            //Education
            University uni = _context.Universities.Find(registerEmployee.UniversityId);     
            ed.Degree = (Degree)Enum.Parse(typeof(Degree), registerEmployee.Degree);
            ed.GPA = registerEmployee.GPA;
            ed.University = uni;


            //Profiling
            Profiling pro = new Profiling
            {
                Education = ed
            };

            //AccountRole
            AccountRole accountRole = new AccountRole
            {
                AccNIK = em.NIK,
                RoleId = 3
            };


            ac.Profiling = pro;
            em.Account = ac;


            _context.Employees.Add(em);
            _context.AccountRoles.Add(accountRole);
            var result = _context.SaveChanges();
            return result;
        }

        public List<RegisterGetAll> GetAll()
        {

            /* var Data = (from emp in _context.Employees
                         join pro in _context.Profilings
                         on emp.NIK equals pro.NIK
                         join edu in _context.Educations
                         on pro.EducationId equals edu.Id
                         join uni in _context.Universities
                         on edu.UniversityId equals uni.Id 
                         select new
                         {
                             FullName = emp.FirstName + " " + emp.LastName,
                             Phone    = emp.Phone,
                             Birthday = emp.Birthday,
                             Salary   = emp.Salary,
                             Email    = emp.Email,

                             Gender   = Enum.GetName(typeof (Gender), emp.Gender),
                             Degree   = Enum.GetName(typeof (Degree), edu.Degree), 
                             GPA      = edu.GPA,
                             UniversityName = uni.Name
                         }).ToList();

             return Data;
 */
            List<RegisterGetAll> registerGetAlls = new List<RegisterGetAll>();
            var Employee = (from emp in _context.Employees
                            select emp).ToList();
            foreach (var emp in Employee)
            {
                var Data = (from pro in _context.Profilings
                           join edu in _context.Educations
                           on pro.EducationId equals edu.Id
                           join unni in _context.Universities
                           on edu.UniversityId equals unni.Id
                           where emp.NIK == pro.NIK
                           select new { 
                                edu.GPA,
                                edu.Id,
                                edu.Degree,
                                unni.Name
                           }).FirstOrDefault();

                RegisterGetAll registerGetAll = new RegisterGetAll
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Phone = emp.Phone,
                    Birthday = emp.Birthday,
                    Salary = emp.Salary,
                    Email = emp.Email,
                    Nik = emp.NIK,
                    Gender = Enum.GetName(typeof(Gender), emp.Gender),
                    Degree = Enum.GetName(typeof(Degree), Data.Degree),
                    GPA = Data.GPA,
                    EduId = Data.Id,
                    UniversityName = Data.Name
                };
                registerGetAlls.Add(registerGetAll);
            }

            return registerGetAlls;
        }

        /*var CheckRole = (from emp in _context.Employees
                         join acr in _context.AccountRoles
                         on emp.NIK equals acr.AccNIK
                         join r in _context.Roles
                         on acr.RoleId equals r.Id
                         where emp.Email == loginVM.Email
                         select r).ToList();
*/


        /*public int Login(LoginVM loginVM)
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
                    return 200;
                }   

                return 404;
            }

            return 400;

        }
        */

        public IEnumerable<Employee> Gets()
        {
            return _context.Employees.ToList();
        }

        public int DeleteAll(Assign NIK)
        {
            var AR = (from a in _context.AccountRoles
                      where a.AccNIK == NIK.NIK
                      select a).FirstOrDefault();
    
            _context.Remove(AR);

            var Pro = _context.Profilings.Find(NIK.NIK);
            var Edu = _context.Educations.Find(Pro.EducationId);
            _context.Remove(Edu);
            _context.Remove(Pro);

            var ACC = _context.Accounts.Find(NIK.NIK);
            _context.Remove(ACC);

            var EMP = _context.Employees.Find(NIK.NIK);
            _context.Remove(EMP);

            return _context.SaveChanges();

        }



        public bool CheckEmail(string email)
        {
            Employee employee = _context.Employees.FirstOrDefault(employee => employee.Email == email);
            return employee != null;
        }


        public bool CheckPhone(string phone)
        {
            Employee employee = _context.Employees.FirstOrDefault(employee => employee.Phone == phone);
            return employee != null;
        }

        public string GetAutoIncrementNIK()
        {
            Employee employee = new Employee();

            var count = (from a in _context.Employees orderby a.NIK select a.NIK).LastOrDefault();
            int lastId;
            if (count == null)
            {
                lastId = 1;
            }
            else
            {
                lastId = Convert.ToInt32(count.Substring(count.Length - 4)) + 1;
            }

            string new_count;

            if (lastId < 10)
            {
                new_count = "000" + lastId;
            }
            else if (lastId < 100)
            {
                new_count = "00" + lastId;
            }
            else if (lastId < 1000)
            {
                new_count = "0" + lastId;
            }
            else
            {
                new_count = lastId.ToString();
            }

            var nik = DateTime.Now.ToString("MMddyyyy") + new_count;

            return nik;
        }  
        public string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public  bool CheckPassword(string password, string correctHash)
        { 

            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

    }
}
