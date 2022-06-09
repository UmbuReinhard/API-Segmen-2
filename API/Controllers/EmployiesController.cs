using API.Models;
using API.Repository;
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
    public class EmployiesController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployiesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
       [HttpGet]
        public ActionResult Get()
        {

           return Ok(employeeRepository.Get());

        }

        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            try
            {
                var result = employeeRepository.Insert(employee);
                if (result == 1)
                {
                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "Insert Berhasil " });
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Insert Gagal" });
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Insert Gagal" });
            }
        }

        [HttpPut]
        public ActionResult Put(Employee employee)
        {
            try
            {
                var result = employeeRepository.Update(employee);

                if (result == 1)
                {
                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "Update Berhasil " });
                }
                else
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Update Gagal" });
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Update Gagal" });
            }
        }

        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            try
            {
                if (string.IsNullOrEmpty(NIK))
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Delete Gagal" });
                }
                else
                {
                    employeeRepository.Delete(NIK);
                    return StatusCode(200, new { status = HttpStatusCode.OK, message = "Delete Berhasil"  });
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, message = "Delete Gagal " + "NIK Tidak Ditemukan !" });
            }
        }

        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            try
            {
                if (employeeRepository.Get(NIK) == null)
                {
                    return StatusCode(400, new { status = HttpStatusCode.NotFound, message = "NIK Tidak Ditemukan !" });
                }
                else
                {
                    return Ok(employeeRepository.Get(NIK)); ;
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.NotFound, message = "NIK Tidak Ditemukan !" });
            }

        }

        [HttpGet]
        [Route("GetFName")]
        public ActionResult GetFName(string FirstName)
        {
            try
            {
                if (employeeRepository.GetFName(FirstName) == null)
                {
                    return StatusCode(400, new { status = HttpStatusCode.NotFound, message = "Nama Tidak Ditemukan !" });
                }
                else
                {
                    return Ok(employeeRepository.GetFName(FirstName));
                }
            }
            catch (Exception)
            {
                return StatusCode(400, new { status = HttpStatusCode.NotFound, message = "Data Kosong" });
            }
        }

    }

}
