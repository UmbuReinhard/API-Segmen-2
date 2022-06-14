using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountRole
    {
        public string AccNIK   { get; set; }
        public virtual Account Account { get; set; }
        public int RoleId      { get; set; }
        public virtual Role Role       { get; set; }
    }
}
