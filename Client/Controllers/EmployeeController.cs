using API.Models;
using API.ViewModel;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository _employeeRepository) : base(_employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllRegis()
        {
            var result = await _employeeRepository.GetAllRegis();
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> InsertEmployee(RegisterEmployeeVM obj)
        {
            var result = await _employeeRepository.InsertEmployee(obj);
            return Json(result);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
