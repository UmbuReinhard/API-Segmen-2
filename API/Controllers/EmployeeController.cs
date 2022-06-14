using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this._employeeRepository = employeeRepository;

        }

        [HttpPost("Register")]
        public ActionResult Post(RegisterEmployeeVM registerEmployee)
        {
            if (_employeeRepository.CheckEmail(registerEmployee.Email))
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Email Sudah Terpakai !" });

            }
            else if (_employeeRepository.CheckPhone(registerEmployee.Phone))
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Nomor Telp Sudah Terpakai !" });
            }
            else
            {
                var result = _employeeRepository.Insert(registerEmployee);
                if (result > 0)
                {
                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "Insert Berhasil " });
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Insert Gagal" });
                }
            }

        }

        [Authorize(Roles = "Directur,Manager")]
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        { 
            return StatusCode(200, new { status = HttpStatusCode.OK, message = "Succes", Data = _employeeRepository.GetAll() });
        }


        [HttpGet("TestCors")]
        public ActionResult TestCors()
        {
            return StatusCode(200,new { m= "test cors berhasil" });
        }


        [HttpGet("Gets")]
        public ActionResult Gets()
        {

            return Ok(_employeeRepository.Gets());

        }

    }
}
