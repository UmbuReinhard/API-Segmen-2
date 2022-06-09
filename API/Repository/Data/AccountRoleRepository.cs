using API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository.Interface;
using API.Models;
using API.ViewModel;

namespace API.Repository.Data
{
    public class AccountRoleRepository 
    {
        private readonly MyContext _context;
        public AccountRoleRepository(MyContext myContext) 
        {
            this._context = myContext;
        }  

        public int SignManager(Assign assign)
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

        }
    }
    

       
    
}
