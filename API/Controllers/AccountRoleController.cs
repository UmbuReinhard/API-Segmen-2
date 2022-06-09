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
    public class AccountRoleController : ControllerBase
    { 
        private readonly AccountRoleRepository _accountRoleRepository;
        public AccountRoleController(AccountRoleRepository accountRoleRepository)
        {
            this._accountRoleRepository = accountRoleRepository;
        }

        [Authorize(Roles = "Directur")]
        [HttpPost("SignManager")]
        public ActionResult SignManager(Assign assign)
        {
           
            if (_accountRoleRepository.SignManager(assign) == 400)
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Sudah Menjadi Manager !" });
            }
            return StatusCode(200, new { status = HttpStatusCode.OK, message = "Berhasil diangkat menjadi Manager" });
        }
    }
        
}
